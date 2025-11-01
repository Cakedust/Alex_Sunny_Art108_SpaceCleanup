using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour, IHittable
{
    public int shiphealth;
    public int shipMaxHealth;
    public Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shiphealth = 0;
        shipMaxHealth = 30;
        healthText.text = string.Concat(shiphealth.ToString() + "/"+ shipMaxHealth.ToString() + " Until Fixed");
    }
    // public void Heal(int healAmount)
    // {
    //     shiphealth += healAmount;
    //     healthText.text = string.Concat(shiphealth.ToString() + "/"+ shipMaxHealth.ToString() + " Until Fixed");
    // }

    public void Hit(int hitAmount)
    {
        shiphealth += hitAmount;
        if (shiphealth >= shipMaxHealth)
        {
            healthText.text = "Ship Fixed!";
        }
        else
        {
            healthText.text = string.Concat(shiphealth.ToString() + "/"+ shipMaxHealth.ToString() + " Until Fixed");
        }

    }
}
