using UnityEngine.UI;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    public Text goldAmountText;
    public Resource gold;

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.gold.ResourceAmount.ToString("0 Gold");
    }
    void Update() {
        UpdateGoldAmountLabel();
    }
}