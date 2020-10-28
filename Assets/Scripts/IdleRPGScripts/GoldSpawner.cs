using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour{
    public GameObject coin;
    public int objectValue;
    private void Start()
    {
        StartCoroutine(SpawnGold(objectValue));
    }

    IEnumerator SpawnGold(int numberOfCoinsToSpawn)
    {
        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            yield return new WaitForSeconds(0.2f);
            var coin = Instantiate(this.coin, this.transform.position, Quaternion.identity);
            coin.transform.SetParent(this.transform);
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
