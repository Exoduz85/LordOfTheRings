using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGold : MonoBehaviour
{
    public int addedGold = 5;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Gold>().GoldAmount = addedGold;
        }
    }
}
