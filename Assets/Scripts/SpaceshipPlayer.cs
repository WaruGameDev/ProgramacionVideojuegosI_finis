using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpaceshipPlayer : MonoBehaviour
{
    public float hp;
    public float maxHp =5;
    public float speed = 5;
    public GameObject bullet;
    public Transform canon;
    public Image bar;

    private void Start()
    {
        hp = maxHp;
    }
    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = hp / maxHp;
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
