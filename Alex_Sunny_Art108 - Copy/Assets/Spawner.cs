using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject newChunk;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3)
        {
            int ranPos = Random.Range(-30, 30);
            Vector3 offset = new Vector3(ranPos,ranPos,10);
            timer = 0;     
            Instantiate(newChunk, transform.position, Quaternion.identity);
        }
    }
}
