using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private Player myPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            myPlayer.GotCoin(1);
            Destroy(gameObject); 
        }

    }
    

}
