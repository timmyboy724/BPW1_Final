using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DestroyTime;
    public bool isBossBullet;
    public int BulletDamage;

    private void Update()
    {
        Destroy(this.gameObject, DestroyTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().DoDamage(BulletDamage);
        }
    }


}
