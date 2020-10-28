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
            var coin = Instantiate(this.coin, new Vector3(this.transform.position.x + 110, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            coin.transform.SetParent(this.transform);
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
