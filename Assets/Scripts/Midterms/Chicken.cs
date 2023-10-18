using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private float timeBeforeLay;
    [SerializeField] private GameObject eggPrefab;
    private void Start()
    {
        timeBeforeLay = Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

        timeBeforeLay -= Time.deltaTime;

        if(timeBeforeLay < 0)
        {
            Vector3 eggSpawn = new Vector3(0, 2, 0);
            GameObject newEgg = Instantiate(eggPrefab, eggSpawn, Quaternion.identity);

            
            GameObject.Destroy(newEgg, 4);

            timeBeforeLay = Random.Range(3f, 5f);

        }

    }
}
