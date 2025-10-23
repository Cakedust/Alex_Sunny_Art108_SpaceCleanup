using UnityEngine;

public class Suck : MonoBehaviour
{
    public GameObject suckEffect;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            suckEffect.SetActive(true);
        }
        else
        {
            suckEffect.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add
    }
}
