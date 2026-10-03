using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipPlayer : MonoBehaviour
{
    public int lifes = 3;
    public float speed = 5;
    public GameObject bullet;
    public Transform canon;

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bullet, canon.position, Quaternion.identity);
        }
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
    }
}
