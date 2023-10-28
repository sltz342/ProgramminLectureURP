using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Transform followTarget;

    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;

    //For shooting

    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletForce;

    //For spawning coins
    [SerializeField] private GameObject coinPrefab;
    private int coinsCollected = 0;

    [Header("Player UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI shotsFired;


    [SerializeField] private float maxHealth;
    private int shotsFiredCounter = 6;
    private float _health;

    [SerializeField] private WeaponBase myWeapon;

    private float Health
    {
        get => _health;
        set { 
            _health = value;
            healthBar.fillAmount = _health / maxHealth;
        }
    }

    void Start()
    {
        InputManager.Init(this);
        InputManager.GameMode();

        shotsFired.text = "Shots Left: " + shotsFiredCounter;
        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;

        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDir);
        CheckGround();

        Health -= Time.deltaTime * 3;
    }

    public void setMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;


    }

    public void spawnBoxOnJ()
    {
        Vector3 coinSpawn = new Vector3(0, 2, 0);
        GameObject newCoin = Instantiate(coinPrefab, coinSpawn, Quaternion.identity);
        Destroy(newCoin.gameObject, 4);
    }

    public void jump() {
        Debug.Log("Jump called");
        if(isGrounded )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    
    }

    private bool fireState;
    public void shootFire()
    {
        /**
        fireState = !fireState;
        if (fireState) myWeapon.StartFiring();
        else myWeapon.StopFiring();
        **/

        if (shotsFiredCounter > 0)
        {
            Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            currentProjectile.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);


            shotsFiredCounter--;

            shotsFired.text = "Shots Left: " + shotsFiredCounter;

            Destroy(currentProjectile.gameObject, 4);
        }
        else
        {
            shotsFired.text = "No Shots Left!";
        }
        
    }
    
    public void reloadGun()
    {
        shotsFiredCounter = 6;
        shotsFired.text = "Reloaded! Shots: " + shotsFiredCounter;
    }

    public void setLookDirection(Vector2 readValue)
    {
        //Controls rotation angles
        currentRotation.x += readValue.x * Time.deltaTime * mouseSensX;
        currentRotation.y += readValue.y * Time.deltaTime * mouseSensY;

        //Controls looking left and right
        transform.rotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.right);

        //Clamps 
        currentRotation.y = Mathf.Clamp(currentRotation.y, minViewAngle, maxViewAngle);

        //
        followTarget.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector2.right);
    }
    
    public void GotCoin(int i)
    {
        coinsCollected = coinsCollected + i;
        Debug.Log("You have collected " + coinsCollected + " coins so far!");
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
    
    
    
    
    cubePrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubePrefab.transform.position = new Vector3(0, 0, 0);
        cubePrefab.AddComponent<Rigidbody>();
        cubePrefab.AddComponent<BoxCollider>();
        cubePrefab.name = "MUSIC MAKE YOU LOSE CONTROl";
     */
    public void getAmmo(int ammoAmount)
    {
        shotsFiredCounter += ammoAmount;
        shotsFired.text = "Ammo Got! Shots: " + shotsFiredCounter;
    }
}
