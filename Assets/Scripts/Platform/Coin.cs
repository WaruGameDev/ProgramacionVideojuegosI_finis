using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationYSpeed = 1;


    void Start()
    {
        
    }

    void Update()
    {

        transform.Rotate(0, rotationYSpeed * Time.deltaTime, 0);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlatformerPlayer>().AddScore(100);

            //collision.gameObject.GetComponent<PlatformerPlayer>().score += 100;
            //Debug.Log("SCORE: " + collision.gameObject.GetComponent<PlatformerPlayer>().score);


            //PlatformerPlayer currentPlayerScript = collision.gameObject.GetComponent<PlatformerPlayer>();
            //currentPlayerScript.score += 100;
            //Debug.Log("SCORE: " + currentPlayerScript.score);

            Destroy(this.gameObject);

        }

    }


}
