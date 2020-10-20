using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI goldAmountText;
    private int _gold;

    public int GoldAmount
    {
        get => PlayerPrefs.GetInt("Gold", 0);
        set
        {
            this._gold += value;
            PlayerPrefs.SetInt("Gold", _gold);
            UpdateGoldAmountLabel();
        }
    }
    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.GoldAmount.ToString("0 Gold");
    }
    private void Start()
    {
        this._gold = PlayerPrefs.GetInt("Gold", 0);
        UpdateGoldAmountLabel();
    }
}
