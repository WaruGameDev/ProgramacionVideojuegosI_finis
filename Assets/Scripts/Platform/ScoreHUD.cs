using UnityEngine;
using TMPro;


public class ScoreHUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // referencia al texto del puntaje
    public PlatformerPlayer platformerPlayer; // referencia al jugador

    public GameObject keyHud;
    public TextMeshProUGUI lifeText; // referencia al texto de vidas   
    public CanvasGroup fader; //pantalla negra al inicio del juego
    public float fadeDuration = 1f; //duración del fade
    private float currentFadeTime = 0f; //tiempo actual del fade
    public bool faderActive = true; //indica si el fader está activo o no

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fader.alpha = 1; // pantalla negra al inicio
        faderActive = false; // activo el fader al inicio
        currentFadeTime = 1f; // reinicio el tiempo del fade
        RefreshScore(); // actualiza el texto del puntaje al inicio
        keyHud.SetActive(false); // oculta el HUD de la llave al inicio
        RefreshLife(); // actualiza el texto de vidas al inicio
    }
    
    public void RefreshLife()
    {
        lifeText.text = $"Vidas: {platformerPlayer.lives}"; // actualiza el texto de vidas
    }
    void Update()
    {
        if(currentFadeTime > 0 && faderActive == false) // si el tiempo del fade es mayor a 0 y el fader no está activo
        {
            currentFadeTime -= Time.deltaTime; // disminuye el tiempo del fade
            fader.alpha = currentFadeTime / fadeDuration; // actualiza la opacidad del fader
        }
        if(currentFadeTime <= 1 && faderActive == true) // si el tiempo del fade es menor o igual a 0 y el fader no está activo
        {
            currentFadeTime += Time.deltaTime; // disminuye el tiempo del fade
            fader.alpha = currentFadeTime / fadeDuration; // actualiza la opacidad del fader
        }
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
