using UnityEngine.UI;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    public Text goldAmountText;
    public Gold gold;

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.gold.GoldAmount.ToString("0 Gold");
    }
    void Update() {
        UpdateGoldAmountLabel();
    }
}