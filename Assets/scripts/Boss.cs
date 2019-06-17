using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    public Target[] targets;

    public Target secondTarget;

    public float Health;
    public Image HealthBar;
    int currentActive;

    public float damageOnHit;

    public GameObject deathObject;

    public Transform endPosition;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float spawnTime;
    public float bulletForce;

    bool isActive = false;
    bool isLow = false;
    GameObject player;
    Vector3 currentPlayerPos;

    public float seconds = 5;

    public BossEnd bs;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HealthBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        currentPlayerPos = player.transform.position;
        HealthBar.fillAmount = Health / 100;

        if (Health <= 0)
        {
            Die();
        }

        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition.position, Time.deltaTime * 0.5f);
        }


    }

    IEnumerator ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

        Vector3 direction = (currentPlayerPos - bullet.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(direction * bulletForce * 10);

        bullet.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        bullet.transform.Rotate(90, 0, 0, Space.Self);

        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(ShootBullet());
    }

    public void LastTarget()
    {
        if (!isLow)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].gameObject.SetActive(false);
            }
            Debug.Log("oef");
            isLow = true;

            secondTarget.gameObject.SetActive(true);
            Health += 50;
            spawnTime = spawnTime / 2;
            bulletForce = bulletForce * 1.3f;
        }
    }

    public void NewTarget()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].isActiveAndEnabled)
            {
                currentActive = i;
            }
            targets[i].gameObject.SetActive(false);
        }

        int randomTarget = Random.Range(0, targets.Length);
        if (randomTarget != currentActive)
        {
            targets[randomTarget].gameObject.SetActive(true);
        }
        else
        {
            NewTarget();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = true;

            HealthBar.gameObject.SetActive(true);
            secondTarget.gameObject.SetActive(false);
            NewTarget();
            StartCoroutine(ShootBullet());
        }
    }

    void Die()
    {
        Instantiate(deathObject, transform.position, transform.rotation);
        bs.End();
        Destroy(this.gameObject);
    }

}
