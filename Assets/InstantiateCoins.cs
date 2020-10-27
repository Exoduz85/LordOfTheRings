using System;
using UnityEngine;

public class InstantiateCoins : MonoBehaviour
{
    public GameObject coinPrefab;
    public float elapsedTime;
    public float waitTime = 0.5f;
    
    public void InstantiateCoinsToSpawn(int numberOfCoinsToSpawn, Vector3 targetPosition)
    {
        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            var coin = Instantiate(this.coinPrefab, targetPosition, Quaternion.identity);
            coin.transform.SetParent(this.transform.parent);
        }
    }
}