using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class Door : MonoBehaviour
{
    public Sprite closedDoorSpriteAsset;
    public Sprite openedDoorSpriteAsset;

    SpriteRenderer sr;

    bool isOpened = false;
    public string nextLevel;

    public ScoreHUD scoreHUD; //Referencia al ScoreHUD para actualizar el puntaje en pantalla

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
                //SceneManager.LoadScene(nextLevel);
                StartCoroutine(NextLevel());
                scoreHUD.faderActive = true; //Activo el fader para hacer el fade out
                //Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("FALTA LA LLAVE!");
            }

        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
        yield return null;
    }
}
