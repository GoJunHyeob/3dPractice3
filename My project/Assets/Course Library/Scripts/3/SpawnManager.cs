using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private Playercontrolller playercontrollerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playercontrollerScript = GameObject.Find("Player").GetComponent<Playercontrolller>();
    }

    void SpawnObstacle()
    {
        if (playercontrollerScript.gameOver == false)
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
