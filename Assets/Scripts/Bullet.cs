using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;

    private void Start()
    {
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
