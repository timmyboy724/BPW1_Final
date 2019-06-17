using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Boss bossScript;

    private void Start()
    {
        bossScript = GetComponentInParent<Boss>();
    }

    public void DoDamage()
    {
        if (bossScript.Health <= bossScript.damageOnHit)
        {
            bossScript.LastTarget();
            bossScript.Health -= bossScript.damageOnHit;
        }
        else
        {
            bossScript.NewTarget();
            bossScript.Health -= bossScript.damageOnHit;
        }
    }
}
