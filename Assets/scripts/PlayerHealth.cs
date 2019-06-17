using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public Image HealthBar;

    private void Update()
    {
        HealthBar.fillAmount = Health / 100;

        if(Health <= 0)
        {
            Die();
        }
    }

    public void DoDamage(int Damage)
    {
        Health -= Damage;


    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
