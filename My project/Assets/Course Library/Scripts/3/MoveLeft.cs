using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private Playercontrolller playercontrollerScript;
    private float leftBound = -15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playercontrollerScript = GameObject.Find("Player").GetComponent<Playercontrolller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrollerScript.gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
