using UnityEngine;
using TMPro;

public class Ring : MonoBehaviour
{
    public int goldAmountPerClick = 5;
    public TextMeshProUGUI goldAmountText;
    public int RingAmount {
        get => PlayerPrefs.GetInt("Gold", 1);
        set {
            PlayerPrefs.SetInt("Gold", value);
            UpdateGoldAmountLabel();
        }
    }

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.RingAmount.ToString("0 Gold");
    }

    void Start() {
        UpdateGoldAmountLabel();
    }
	
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ProduceGold();
        }
    }

    public void ProduceGold() {
        this.RingAmount += this.goldAmountPerClick; // this.goldAmount = this.goldAmount + goldAmountPerClick;
    }
}
