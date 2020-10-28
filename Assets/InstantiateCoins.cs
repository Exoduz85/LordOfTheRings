using System;
using UnityEngine;

public class InstantiateCoins : MonoBehaviour
{
    public GameObject coinPrefab;
    public float elapsedTime;
    public float waitTime = 0.5f;
    public Vector3 spawnPosition;
    public int numberOfCoinsToSpawn;
    public bool shouldSpawn;
    private void Update() {
        if (shouldSpawn) {
            InstantiateCoinsToSpawn();
        }
    }

    public void InstantiateCoinsToSpawn() {
        for (int i = 0; i < numberOfCoinsToSpawn; i++) {
            var coin = Instantiate(this.coinPrefab, spawnPosition, Quaternion.identity);
            coin.transform.SetParent(this.transform.parent);
        }
        shouldSpawn = false;
    }
}