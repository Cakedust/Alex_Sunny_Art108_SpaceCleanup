using System;
using NUnit.Framework;
using UnityEngine;

public class Suckable : MonoBehaviour
{
    public GameObject target;
    public float speedIncrease = 3;
    public float maxSpeed = 15;
    //public BoxCollider2D suckforce;
    private Rigidbody2D thingRigidbody;
    private bool isAccelerating = false;
    public LogicScript destroyLogic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player");
        thingRigidbody = GetComponent<Rigidbody2D>();
        destroyLogic = GameObject.FindGameObjectWithTag("LogicDestroy").GetComponent<LogicScript>();
    }
    //if it hit the player object, disappears and is added to player "iventory"
    void OnTriggerEnter2D(Collider2D col)
    {
        //detects if object is player, where it gets vacuumed
        if (col.gameObject.CompareTag("Player") & Input.GetMouseButton(1) & destroyLogic.getResource() < destroyLogic.getMaxResource())
        {
            Destroy(gameObject);
            destroyLogic.addResource();
        }
        //detects if object is ship, in case heals it
        IHittable iHit = col.gameObject.GetComponent<IHittable>();
        if (iHit != null)
        {
            if (col.gameObject.CompareTag("Ship"))
            {
                iHit.Hit(1);
                //col.iHeal.Heal(1);
                Destroy(gameObject);
                //col.gameObject.heal();
            }
        }
        
        // IHealable iHeal = col.gameObject.GetComponent<IHealable>();
        // if (iHeal != null)
        // {
        //     iHeal.heal(1);
        //     Destroy(gameObject);
        // }
    }
    //every frame its within the collider of the vacuum it is accerating
    void OnTriggerStay2D(Collider2D col)
    {
        isAccelerating = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        isAccelerating = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // float angleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
        // float angleDeg = (float)((180 / Math.PI) * angleRad-90);
        // transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);
        if (isAccelerating)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            thingRigidbody.AddForce(speedIncrease * direction); 
            thingRigidbody.linearVelocity = Vector3.ClampMagnitude(thingRigidbody.linearVelocity, maxSpeed);
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = transform.position.z;
        }
        //Debug.DrawLine(transform.position, 0, Color.white, Time.deltaTime);
    }
}
