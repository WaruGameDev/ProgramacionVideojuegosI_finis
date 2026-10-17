using System;
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

    public ScoreHUD scoreHUD; //Referencia al ScoreHUD para actualizar el puntaje en pantalla
    public Transform respawnPoint; //Referencia al punto de respawn del jugador

    public int lives = 3; //Cantidad de vidas del jugador

    public AudioSource coinSound; //Referencia al AudioSource del sonido de la moneda

    public Animator animator; //Referencia al Animator del jugador
    public SpriteRenderer spriteRenderer; //Referencia al SpriteRenderer del jugador

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
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Resetear la escena
            Death(); //Llamo a la funcin de muerte del jugador
        }
        animator.SetFloat("speed", MathF.Abs(rb.linearVelocity.x));
        animator.SetFloat("verticalSpeed", MathF.Abs(rb.linearVelocity.y));
        if(rb.linearVelocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(rb.linearVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
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
        coinSound.Play(); //Reproduzco el sonido de la moneda
        scoreHUD.RefreshScore(); //Actualizo el puntaje en pantalla
       
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;


            if(collision.relativeVelocity.y > maxFallDamage) //Si la velocidad de caida es mayor a la velocidad m�xima de da�o, entonces reinicio la escena
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                Death(); //Llamo a la funcin de muerte del jugador
            }




        }

        if(collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Enemy")) //Si es un Hazard O es un Enemy
        {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Death(); //Llamo a la funci�n de muerte del jugador
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

    public void Death()
    {
        
        lives--;
        
        if(lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Resetear la escena
        }
        else
        {
            transform.position = respawnPoint.position; //Respawnear al jugador en el punto de respawn
            rb.linearVelocity = Vector2.zero; //Reiniciar la velocidad del jugador al respawnear
        }
        scoreHUD.RefreshLife(); //Actualizo el puntaje en pantalla
    }




}
