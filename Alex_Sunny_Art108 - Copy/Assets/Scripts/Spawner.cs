using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject newChunk;
    public int spawnDistance = 5;
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
            int ranPosX = Random.Range(-spawnDistance, spawnDistance);
            int ranPosY = Random.Range(-spawnDistance, spawnDistance);
            Vector3 offset = new Vector3(ranPosX,ranPosY,10);
            timer = 0;     
            Instantiate(newChunk, transform.position+offset, Quaternion.identity);
        }
    }
}
