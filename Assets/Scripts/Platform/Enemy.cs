using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;

    int direction = 0;

    bool isFacingRight = false;

    SpriteRenderer sr;

    float timer = 0;
    public float changeDirectionTime = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        timer = changeDirectionTime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDirectionTime)
        {
            isFacingRight = !isFacingRight;
            sr.flipX = !sr.flipX;
            timer = 0;
        }


        if (isFacingRight == true)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }





    



}
