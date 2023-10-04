using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //Vars for lect 5
    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;

    private Vector2 currentRotation;
    [SerializeField] private Transform LookatPoint;

    [SerializeField, Range(0, 180)] private float minViewAngle;
    [SerializeField, Range(0, 180)] private float maxViewAngle;

    //For shooting

    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulleForce;



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

    public void shootFire()
    {
        Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        currentProjectile.AddForce(LookatPoint.forward * bulleForce, ForceMode.Impulse);

        Destroy(currentProjectile.gameObject, 4);
    }

    public void setLookDirection(Vector3 readValue)
    {
        //Controls rotation angles
        currentRotation.x += readValue.x * Time.deltaTime * mouseSensX;
        currentRotation.y += readValue.y * Time.deltaTime * mouseSensY;

        //Controls looking left and right
        transform.rotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        LookatPoint.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.right);

        //Clamps 
        currentRotation.y = Mathf.Clamp(currentRotation.y, minViewAngle, maxViewAngle);

        //
        LookatPoint.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector2.right);
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
