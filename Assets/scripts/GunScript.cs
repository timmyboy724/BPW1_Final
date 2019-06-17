using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPosition;
    public float bulletForce;
    public float firerate= 0.5f;
    private float nextfire;
    public Animator anim;
    public AudioClip shot;
    public AudioSource source;

    public int maxBullets;
    int currentBullets;
    public float reloadTime;

    public Text bullets;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponentInParent<Camera>();

        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        bullets.text = currentBullets + " / " + maxBullets;

        if (Input.GetKeyDown(KeyCode.Mouse0)&& Time.time > nextfire && currentBullets > 0)
        {
            currentBullets--;
            nextfire = Time.time + firerate;

            GameObject bulletClone = Instantiate(bulletPrefab, bulletPosition.transform.position, bulletPosition.transform.rotation);
            bulletClone.GetComponent<Rigidbody>().AddForce(bulletPosition.transform.forward * bulletForce * 10);

            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                 if(hit.collider.tag == "Target")
                {
                    hit.collider.GetComponent<Target>().DoDamage();
                }
            }
            anim.Play("Shoot");
            source.PlayOneShot(shot);
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        currentBullets = maxBullets;
    }
}
