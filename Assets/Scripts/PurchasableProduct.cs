﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PurchasableProduct
{
    public string name;
    public int cost;
    public int productionTime;

    public int productionAmount
    {
        get => _productionAmount;
        set => this._productionAmount = value;
    }
    private int _productionAmount;

    public PurchasableProduct(string name, int cost, int productionTime, int productionAmount)
    {
        this.name = name;
        this.cost = cost;
        this.productionTime = productionTime;
        this.productionAmount = productionAmount;
    }
}