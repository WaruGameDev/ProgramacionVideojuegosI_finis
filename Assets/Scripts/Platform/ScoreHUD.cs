using UnityEngine;
using TMPro;

public class ScoreHUD : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // referencia al texto del puntaje
    public PlatformerPlayer platformerPlayer; // referencia al jugador

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshScore(); // actualiza el texto del puntaje al inicio
    }

    public void RefreshScore()
    {
        scoreText.text = $"Puntaje: {platformerPlayer.score}"; // actualiza el texto del puntaje
    }
}
