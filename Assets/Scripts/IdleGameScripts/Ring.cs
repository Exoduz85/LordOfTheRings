using UnityEngine;
using TMPro;

public class Ring : MonoBehaviour
{
    public int ringAmountPerClick = 5;
    public TextMeshProUGUI goldAmountText;
    public int RingAmount {
        get => PlayerPrefs.GetInt("Rings", 1);
        set {
            PlayerPrefs.SetInt("Rings", value);
            UpdateGoldAmountLabel();
        }
    }

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.RingAmount.ToString("0 Rings");
    }

    void Start() {
        UpdateGoldAmountLabel();
    }
    public void ProduceGold() {
        this.RingAmount += this.ringAmountPerClick; // this.goldAmount = this.goldAmount + goldAmountPerClick;
    }
}
