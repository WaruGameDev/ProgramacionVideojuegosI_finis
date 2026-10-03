using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 5f;
    public int scoreToAdd = 100;
    public float timeToFlash = .25f;
    public SpriteRenderer spriteRenderer;
    private float currentTimeToFlash = 0;
    public GameObject fx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {           
            Destroy(other.gameObject); //destruir bala
            hp--;
            currentTimeToFlash = timeToFlash;
            if(hp <= 0)
            {
                Instantiate(fx, transform.position, Quaternion.identity);
                GameManager.instance.AddScore(scoreToAdd);
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        if (currentTimeToFlash > 0)
        {
            currentTimeToFlash -= Time.deltaTime;
            spriteRenderer.color = Color.red;
            if (currentTimeToFlash <= 0)
            {
                spriteRenderer.color = Color.white;
            }
        }
    }
}
