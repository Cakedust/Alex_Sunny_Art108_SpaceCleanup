using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public float followSpeed = 30;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x, target.position.y, 0);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed*Time.deltaTime);
    }
}
