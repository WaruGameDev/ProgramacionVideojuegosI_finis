using UnityEngine;

public class Key : MonoBehaviour
{
    public Door doorObjectScript; 
    public ScoreHUD scoreHUD; //Referencia al ScoreHUD para actualizar el puntaje en pantalla  


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            doorObjectScript.OpenDoor();
            scoreHUD.ShowKeyHUD(); //Muestro el HUD de la llave
            Destroy(this.gameObject);
        }
    }
}
