using UnityEngine;

using UnityEngine.SceneManagement;



public class PlatformerPlayer : MonoBehaviour
{
    float horizontalInput; 
    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D rb;
    public bool canJump = false;

    public int score = 0;
    public float maxFallDamage = 8f; //Da�o m�ximo que puede recibir el jugador al caer



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        /*
        if(rb.linearVelocity.y == 0)
        {
            canJump = true;
        }
        */

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //Si justo apret� la tecla "Espacio", entonces hago algo
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                //Aqui salto
                canJump = false;

            }
        }

        //Debug.Log("CanJump?: " + canJump); //CanJump?: true    //CanJump?: false

        if(rb.linearVelocity.y < -2) //Si est� en caida libre, entonces, no puede saltar!
        {
            canJump = false;
        }
        
        if(transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Resetear la escena
        }

    }
    void FixedUpdate()
    {

        //transform.Translate(Vector2.right * moveSpeed);
        //rb.AddForce(Vector2.right * moveSpeed * horizontalInput);
        
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);


    }


    public void AddScore(int addedScore)
    {
        score += addedScore;
        Debug.Log("SCORE: " + score);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;


            if(collision.relativeVelocity.y > maxFallDamage) //Si la velocidad de caida es mayor a la velocidad m�xima de da�o, entonces reinicio la escena
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }




        }

        if(collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Enemy")) //Si es un Hazard O es un Enemy
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Destroy(collision.gameObject);

            canJump = false;

        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spring"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 2.7f);

        }

        if(collision.gameObject.CompareTag("EnemyHitPoint"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 0.5f);
            AddScore(300);
            Destroy(collision.transform.parent.gameObject);

        }
    }




}
