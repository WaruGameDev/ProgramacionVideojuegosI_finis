using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite closedDoorSpriteAsset;
    public Sprite openedDoorSpriteAsset;

    SpriteRenderer sr;

    bool isOpened = false;
    public string nextLevel;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedDoorSpriteAsset;
        isOpened = false;
    }

    public void OpenDoor()
    {
        sr.sprite = openedDoorSpriteAsset;
        isOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(isOpened == true)
            {
                collision.gameObject.transform.localScale = new Vector3(5, 5, 5);
                SceneManager.LoadScene(nextLevel);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("FALTA LA LLAVE!");
            }

        }
    }
}
