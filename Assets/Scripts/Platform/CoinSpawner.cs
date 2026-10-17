using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // moneda a spawnear
    public Transform[] spawnPoints; // punto de spawn de la moneda
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform t in spawnPoints)
        {
            Instantiate(coinPrefab, t.position, Quaternion.identity);
        }
    }

   
}
