using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class RingProducer : MonoBehaviour {
    public RingProductionData RingProductionData;
    public Text ringAmountText;
    public Text purchaseButtonLabel;
    public Text floatingEarningsPrefab;
    public Button button;
    public ColorBlock colors;
    float elapsedTime;
    bool IsAffordable => FindObjectOfType<Ring>().RingAmount >= this.RingProductionData.GetActualCosts(this.RingMakerAmount);

    public void SetUp(RingProductionData ringProductionUnit) {
        this.RingProductionData = ringProductionUnit;
        this.gameObject.name = ringProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase for {this.RingProductionData.GetActualCosts(this.RingMakerAmount)}";
    }
    public int RingMakerAmount {
        get => PlayerPrefs.GetInt(this.RingProductionData.name, 0); // recommend not to use same key for float/int etc
        set {
            PlayerPrefs.SetInt(this.RingProductionData.name, value);
            UpdateRingPressAmountLabel();
        }
    }

    public void Purchase() {
        if (this.IsAffordable) {
            var ring = FindObjectOfType<Ring>();
            ring.RingAmount -= this.RingProductionData.GetActualCosts(this.RingMakerAmount);
            this.RingMakerAmount += 1;
            this.purchaseButtonLabel.text = $"Purchase for {this.RingProductionData.GetActualCosts(this.RingMakerAmount)}";
        }
    }
    
    void UpdateRingPressAmountLabel() {
        this.ringAmountText.text = this.RingMakerAmount.ToString($"0 {this.RingProductionData.name}");
    }
    void Start()
    {
        UpdateRingPressAmountLabel();
        colors = new ColorBlock();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.RingProductionData.productionTime) {
            if (this.RingMakerAmount != 0) {
                ProduceRing();
                FloatingEarnText();
            }
            this.elapsedTime -= this.RingProductionData.productionTime;
        }
        ChangeColorStateButton();
    }
    void ProduceRing() {
        if (this.RingMakerAmount == 0)
            return;
        var ring = FindObjectOfType<Ring>();
        ring.RingAmount += this.RingProductionData.ProductionAmount * this.RingMakerAmount;
    }
    void FloatingEarnText() {
        floatingEarningsPrefab.text = (this.RingProductionData.ProductionAmount * this.RingMakerAmount).ToString();
        var earnTextInstance = Instantiate(floatingEarningsPrefab, this.transform.position, quaternion.identity);
        earnTextInstance.transform.SetParent(this.transform);
    }
    public void ChangeColorStateButton() {
        var ring = FindObjectOfType<Ring>();
        colors = button.colors;
        colors.highlightedColor = this.IsAffordable ? Color.green : Color.red;
        button.colors = colors;
    }
}