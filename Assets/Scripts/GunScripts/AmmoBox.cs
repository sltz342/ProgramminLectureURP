using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int ammoAmount;

    [SerializeField] private Player currentPlayer;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,30*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider otherCollision)
    {
        if (otherCollision.tag == "Player")
        {
            currentPlayer.getAmmo(ammoAmount);
        }
    }
}
