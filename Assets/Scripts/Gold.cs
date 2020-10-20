using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gold : MonoBehaviour
{
    private TextMeshProUGUI goldAmountText;
    private int gold;
    public int GoldAmount {get => this.gold; set => this.gold += value; }

    private void Start()
    {
        this.gold = PlayerPrefs.GetInt("Gold", 0);
        goldAmountText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        goldAmountText.text = GoldAmount.ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Gold", gold);
    }
}
