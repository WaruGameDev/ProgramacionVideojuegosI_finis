using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    private void Awake()
    {
        instance = this;
    }
    public void AddScore(int _score)
    {
        score += _score;
    }
}
