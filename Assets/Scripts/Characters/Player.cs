using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _moveDir;
    public GameObject cubePrefab;


    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.GameMode();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  (speed * Time.deltaTime * _moveDir);


    }
    public void setMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;


    }

    public void spawnBoxOnJ()
    {

        Instantiate(cubePrefab, transform.position, Quaternion.identity);

    }
}
