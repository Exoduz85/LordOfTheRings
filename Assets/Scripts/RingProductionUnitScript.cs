using UnityEngine;
using TMPro;

public class RingProductionUnitScript : MonoBehaviour {
    public RingProductionUnit ringProductionUnit;
    public TextMeshProUGUI ringAmountText;
    public TextMeshProUGUI purchaseButtonLabel;
    float elapsedTime;

    public void SetUp(RingProductionUnit ringProductionUnit) {
        this.ringProductionUnit = ringProductionUnit;
        this.gameObject.name = ringProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {ringProductionUnit.name}";
    }
	
    public int RingPressAmount {
        get => PlayerPrefs.GetInt(this.ringProductionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.ringProductionUnit.name, value);
            UpdateRingPressAmountLabel();
        }
    }

    void UpdateRingPressAmountLabel() {
        this.ringAmountText.text = this.RingPressAmount.ToString($"0 {this.ringProductionUnit.name}");
    }

    void Start() {
        UpdateRingPressAmountLabel();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.ringProductionUnit.productionTime) {
            ProduceRing();
            this.elapsedTime -= this.ringProductionUnit.productionTime; // DO NOT SET TO ZERO HERE
        }
    }
    // something costs 100ct, and I get 40ct per day:
    // IN CASE WE SET IT TO ZERO:
    // 40ct 80ct [120ct (Buy for 100ct) 0ct] 40ct 80ct // In 5 Days, I can buy something for 100ct once, and I have 80ct
    // IN CASE WE DECREASE IT BY THE COSTS:
    // 40ct 80ct [120ct (Buy for 100ct) 20ct] 60ct [100ct (Buy for 100ct) 0ct] // In 5 Days, I can buy something for 100ct twice

    void ProduceRing() {
        var ring = FindObjectOfType<Ring>();
        ring.RingAmount += this.ringProductionUnit.productionAmount * this.RingPressAmount;
    }

    public void BuyGoldPress() {
        var ring = FindObjectOfType<Ring>();
        if (ring.RingAmount >= this.ringProductionUnit.costs) {
            ring.RingAmount -= this.ringProductionUnit.costs;
            this.RingPressAmount += 1;
        }
    }
}