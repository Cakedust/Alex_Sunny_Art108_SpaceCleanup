using NUnit.Framework;
using UnityEngine;

public class Suckable : MonoBehaviour
{
    private Vector3 target;
    public float speedIncrease = 2;
    public BoxCollider2D suckforce;
    private Rigidbody2D thingRigidbody;
    private bool isAccelerating = false;
    public float maxSpeed = 30;
    public Transform player;
    public LogicScript destroyLogic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = transform.position;
        thingRigidbody = GetComponent<Rigidbody2D>();
    }
    //every frame its within the collider of the vacuum it is accerating
    void OnTriggerStay2D(Collider2D suckforce)
    {
        isAccelerating = true;
    }
    void OnTriggerExit2D(Collider2D suckforce)
    {
        isAccelerating = false;
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        if (isAccelerating)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            thingRigidbody.AddForce(speedIncrease * direction);
            thingRigidbody.linearVelocity = Vector3.ClampMagnitude(thingRigidbody.linearVelocity, maxSpeed);
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = transform.position.z;
        }
        Debug.DrawLine(transform.position, player.transform.position, Color.white, Time.deltaTime);
    }
}
