using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speedIncrease = 1;
    //private Vector3 target;
    public float maxSpeed = 30;
    public float fireSpeed = 5;
    public GameObject newChunk;
    private bool isAccelerating = false;
    private Rigidbody2D playerRigidbody;
    private Camera cam;
    private Vector3 mousePos;
    public LogicScript destroyLogic;

    //public LogicScript destroyLogic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //target = transform.position;
        playerRigidbody = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        destroyLogic = GameObject.FindGameObjectWithTag("LogicDestroy").GetComponent<LogicScript>();
        //destroyLogic = GameObject.FindGameObjectWithTag("LogicDestroy").GetComponent<LogicScript>();
    }
    // Update is called once per frame
    void Update()
    {
        //detects acceleration input
        isAccelerating = Input.GetMouseButton(1);
        //call rotation fuction
        handleRotation();
        //call shooting function
        handleFire();
    }
    private void handleFire()
    {
        //detects fire input
        if (Mouse.current.leftButton.wasPressedThisFrame & (destroyLogic.getResource() > 0))
        {
            //spawn spacejunk with velocity
            GameObject firedJunk = Instantiate(newChunk, transform.position, Quaternion.identity);
            Vector3 direction = mousePos - firedJunk.transform.position;
            firedJunk.GetComponent<Rigidbody2D>().linearVelocity = direction * fireSpeed;
            //subtract from rescources
            destroyLogic.removeResource();
        }
    }
    private void handleRotation()
    {
        //faces arems towards mouse position 
        mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (float)((180 / Math.PI) * angleRad);
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
        //makes debug line
        Debug.DrawLine(transform.position, mousePos, Color.white, Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //if rightmouse is held
        if (isAccelerating)
        {
            playerRigidbody.AddForce(speedIncrease * transform.right);
            playerRigidbody.linearVelocity = Vector3.ClampMagnitude(playerRigidbody.linearVelocity, maxSpeed);
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = transform.position.z;
        }
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     destroyLogic.addResource();
    // }
}
