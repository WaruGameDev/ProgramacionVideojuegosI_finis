using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    SpriteRenderer sr;
    PlatformerPlayer playerScript;

    public Sprite spriteIdleAsset;
    public Sprite spriteJumpAsset;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlatformerPlayer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0) //derecha
        {
            sr.flipX = false;
        }
        else if (horizontalInput < 0) //izquierda
        {
            sr.flipX = true;
        }

        if(playerScript.canJump) //esta en tierra
        {
            sr.sprite = spriteIdleAsset;
        }
        else //esta en el aire
        {
            sr.sprite = spriteJumpAsset;
        }
    }
}
