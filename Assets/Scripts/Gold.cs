using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gold : MonoBehaviour
{
    private TextMeshProUGUI goldAmountText;
    private int gold = 0;
    public int GoldAmount {get => this.gold; set => this.gold += value; }

    private void Start()
    {
        goldAmountText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        goldAmountText.text = GoldAmount.ToString();
    }
}
