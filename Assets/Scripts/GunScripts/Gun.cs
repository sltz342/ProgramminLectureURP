using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    //Make this an array of projectiles for the shotgun
    [SerializeField] private Rigidbody[] projectile;
    [SerializeField] private float force;


    protected override void Attack(float chargePercent)
    {
        int option = 0;

        switch (chargePercent)
        {
            case < 0.2f:
                break;
            case < 0.5f:
                option = 1; 
                break;
            default:
                option = 2;
                break;
        }


        Rigidbody spawnProjectile = Instantiate(projectile[option], transform.position, transform.rotation);
        spawnProjectile.AddForce(force * chargePercent * transform.forward, ForceMode.Impulse);


        Debug.Log("I Attacked!: " + chargePercent);
    }



}
