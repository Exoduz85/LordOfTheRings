using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour
{
    public Text goldAmountText;
    public Image closetChest;
    public Image openChest;

    void updateGoldAmount(int amountGold)
    {
        goldAmountText.text = amountGold.ToString("Gold: 0");
    }
    
}
