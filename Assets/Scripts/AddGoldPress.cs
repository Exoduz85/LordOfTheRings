using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoldPress : MonoBehaviour
{
    public PurchasableProduct goldPresser;
    public void Start()
    {
        goldPresser = new PurchasableProduct("Gold Presser", 100, 1, 1);
    }
    
}
