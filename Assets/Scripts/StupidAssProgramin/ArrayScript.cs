using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayScript : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Color[] colors;
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            objects[i].GetComponent<Renderer>().material.color = colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
