using UnityEngine.UI;
using UnityEngine;

public class RingUI : MonoBehaviour
{
    public Text goldAmountText;
    public Ring ring;

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.ring.RingAmount.ToString("0 Gold");
    }
    void Update() {
        UpdateGoldAmountLabel();
    }
}