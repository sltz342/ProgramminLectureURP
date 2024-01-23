using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    [SerializeField] private GameObject block;
    public int width = 10;
    public int height = 4;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int zPos = 0;
        for (int i = 0; i < height; i++)
        {

            for (int y = 0; y < width; y++)
            {

                Instantiate(block, new Vector3(i, y, zPos), Quaternion.identity);
            }

            zPos = zPos + 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
