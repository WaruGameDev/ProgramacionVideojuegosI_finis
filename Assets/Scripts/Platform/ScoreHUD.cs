using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;


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
    public CanvasGroup winScreen; //pantalla de victoria
    public string nextLevel; //nombre de la siguiente escena a cargar

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
    public void ShowWinScreen()
    {
        winScreen.DOFade(1, 1f); // hace el fade in de la pantalla de victoria
        winScreen.interactable = true; // hace que la pantalla de victoria sea interactuable
        winScreen.blocksRaycasts = true; // hace que la pantalla de victoria bloquee los raycasts
    }
    public void RestartLevel()
    { 
        fader.interactable = true; // hace que el fader sea interactuable para que pueda bloquear los raycasts mientras se hace el fade in
        fader.blocksRaycasts = true; // hace que el fader sea interactuable y
        fader.DOFade(1, 1f).OnComplete(() => {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reinicia la escena actual
        }); // hace el fade in de la pantalla negra al reiniciar el nivel
       
    }
    public void BackToMainMenu()
    {
        fader.interactable = true; // hace que el fader sea interactuable para que pueda bloquear los raycasts mientras se hace el fade in
        fader.blocksRaycasts = true; // hace que el fader sea interactuable y bloquee los raycasts para que no se pueda interactuar con el menú mientras se hace el fade in
        fader.DOFade(1, 1f).OnComplete(() => {
            SceneManager.LoadScene("Menu"); // carga la escena del menú principal
        }); // hago el fade in de la pantalla negra al volver al menú principal
    }

    public void LoadNextLevel()
    {
        fader.interactable = true; // hace que el fader sea interactuable para que pueda bloquear los raycasts mientras se hace el fade in
        fader.blocksRaycasts = true; // hace que el fader sea interactuable y bloquee los raycasts para que no se pueda interactuar con el menú mientras se hace el fade in
        fader.DOFade(1, 1f).OnComplete(() => {
            SceneManager.LoadScene(nextLevel); // carga la siguiente escena
        }); // hago el fade in de la pantalla negra al cargar la siguiente escena
    }
}
