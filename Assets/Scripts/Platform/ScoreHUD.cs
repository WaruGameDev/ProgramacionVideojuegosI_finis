using UnityEngine;
using TMPro;


public class ScoreHUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // referencia al texto del puntaje
    public PlatformerPlayer platformerPlayer; // referencia al jugador

    public GameObject keyHud;
    public TextMeshProUGUI lifeText; // referencia al texto de vidas    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshScore(); // actualiza el texto del puntaje al inicio
        keyHud.SetActive(false); // oculta el HUD de la llave al inicio
        RefreshLife(); // actualiza el texto de vidas al inicio
    }
    public void RefreshLife()
    {
        lifeText.text = $"Vidas: {platformerPlayer.lives}"; // actualiza el texto de vidas
    }
   

    public void RefreshScore()
    {
        scoreText.text = $"Puntaje: {platformerPlayer.score}"; // actualiza el texto del puntaje
    }
    public void ShowKeyHUD()
    {
        keyHud.SetActive(true); // muestra el HUD de la llave
    }
}
