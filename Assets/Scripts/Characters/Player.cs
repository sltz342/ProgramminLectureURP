using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   //Vars for speeds
    [SerializeField] private float speed;

    //Vars for jumping
    [SerializeField] private float jumpForce;
    private Boolean isGrounded;
    private Rigidbody rb;
    private float depth;

    [SerializeField] private LayerMask groundLayers;


    //Vars for movement and cubePrefab
    private Vector3 _moveDir;
    public GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.GameMode(); 

        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  (speed * Time.deltaTime * _moveDir);
        CheckGround();
        
    }
    public void setMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;


    }

    public void spawnBoxOnJ()
    {
        
        cubePrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubePrefab.transform.position = new Vector3(0, 0, 0);
        cubePrefab.AddComponent<Rigidbody>();
        cubePrefab.AddComponent<BoxCollider>();
        cubePrefab.name = "MUSIC MAKE YOU LOSE CONTROl";
        
    }

    public void jump() {
        Debug.Log("Jump called");
        if(isGrounded )
        {
            Debug.Log("this bitch jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    
    }
    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, depth, groundLayers);

        Debug.DrawRay(transform.position, Vector3.down * depth, Color.red, 0, false);
    }

    /** Start checkground that got edited
    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);

        Debug.DrawRay(transform.position, Vector3.down * GetComponent<Collider>().bounds.size.y, Color.red, 0, false);
    }
     */
}
