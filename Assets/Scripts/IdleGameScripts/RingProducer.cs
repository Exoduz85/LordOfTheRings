using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class RingProducer : MonoBehaviour {
    public RingProductionData ringProductionUnit;
    public Text ringAmountText;
    public Text purchaseButtonLabel;
    public Text floatingEarningsPrefab;
    public Button button;
    public ColorBlock colors;
    float elapsedTime;

    public void SetUp(RingProductionData ringProductionUnit) {
        this.ringProductionUnit = ringProductionUnit;
        this.gameObject.name = ringProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {ringProductionUnit.name} for {(int)this.ringProductionUnit.costs} rings.";
    }
    public int RingMakerAmount {
        get => PlayerPrefs.GetInt(this.ringProductionUnit.name, 0); // recommend not to use same key for float/int etc
        set {
            PlayerPrefs.SetInt(this.ringProductionUnit.name, value);
            UpdateRingPressAmountLabel();
        }
    }
    void UpdateRingPressAmountLabel() {
        this.ringAmountText.text = this.RingMakerAmount.ToString($"0 {this.ringProductionUnit.name}");
    }
    void UpdateCostAmountLabel() {
        this.purchaseButtonLabel.text = $"Purchase {ringProductionUnit.name} for {(int)this.ringProductionUnit.costs} rings.";
    }

    void Start()
    {
        this.ringProductionUnit.costs = PlayerPrefs.GetFloat(this.ringProductionUnit.costKey, this.ringProductionUnit.costs);
        UpdateCostAmountLabel();
        UpdateRingPressAmountLabel();
        colors = new ColorBlock();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.ringProductionUnit.productionTime) {
            if (this.RingMakerAmount != 0) {
                ProduceRing();
                FloatingEarnText();
            }
            this.elapsedTime -= this.ringProductionUnit.productionTime;
        }
        ChangeColorStateButton();
    }
    void ProduceRing() {
        var ring = FindObjectOfType<Ring>();
        ring.RingAmount += this.ringProductionUnit.productionAmount * this.RingMakerAmount;
        
    }
    void FloatingEarnText() {
        floatingEarningsPrefab.text = (this.ringProductionUnit.productionAmount * this.RingMakerAmount).ToString();
        var earnTextInstance = Instantiate(floatingEarningsPrefab, this.transform.position, quaternion.identity);
        earnTextInstance.transform.SetParent(this.transform);
    }
    public void BuyRingProductionUnit() {
        var ring = FindObjectOfType<Ring>();
        if (ring.RingAmount >= (int)this.ringProductionUnit.costs) {
            ring.RingAmount -= (int)this.ringProductionUnit.costs;
            this.RingMakerAmount += 1;
            this.ringProductionUnit.costs *= 1.07f;
            PlayerPrefs.SetFloat(this.ringProductionUnit.costKey, this.ringProductionUnit.costs);
            UpdateCostAmountLabel();
        }
    }
    public void ChangeColorStateButton() {
        var ring = FindObjectOfType<Ring>();
        colors = button.colors;
        colors.highlightedColor = ring.RingAmount >= this.ringProductionUnit.costs ? Color.green : Color.red;
        button.colors = colors;
    }
}