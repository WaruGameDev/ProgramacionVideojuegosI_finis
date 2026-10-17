using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public CanvasGroup fader; //Referencia al CanvasGroup del fader
    public GameObject mainMenu; //Referencia al GameObject del menú principal
    public GameObject optionsMenu; //Referencia al GameObject del menú de opciones
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fader.alpha = 1; // pantalla negra al inicio
        fader.DOFade(0, 1f).OnComplete(() => 
        { 
            fader.interactable = false; // hago que el fader no sea interactuable para que no bloquee los raycasts mientras se hace el fade out
            fader.blocksRaycasts = false; // hago que el fader no sea interactuable y no bloquee los raycasts para que se pueda interactuar con el menú mientras se hace el fade out
        }); // hago el fade out de la pantalla negra al inicio del juego
    }

    public void StartGame()
    {
        fader.interactable = true; // hago que el fader sea interactuable para que pueda bloquear los raycasts mientras se hace el fade in
        fader.blocksRaycasts = true; // hago que el fader sea interactuable y bloquee los raycasts para que no se pueda interactuar con el menú mientras se hace el fade in
        fader.DOFade(1, 1f).OnComplete(() => {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel1"); // cargo la escena del juego
        }); // hago el fade in de la pantalla negra al iniciar el juego
    }
    public void OpenOptionsMenu()
    {
        mainMenu.SetActive(false); // desactivo el menú principal
        optionsMenu.SetActive(true); // activo el menú de opciones
    }
    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false); // desactivo el menú de opciones
        mainMenu.SetActive(true); // activo el menú principal
    }
    public void QuitGame()
    {
        Application.Quit(); // cierro el juego
    }
}
