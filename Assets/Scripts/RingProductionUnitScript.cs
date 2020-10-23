using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class RingProductionUnitScript : MonoBehaviour {
    public RingProductionUnit ringProductionUnit;
    public TextMeshProUGUI ringAmountText;
    public TextMeshProUGUI purchaseButtonLabel;
    public TextMeshProUGUI floatingEarningsPrefab;
    public Button button;
    public ColorBlock colors;
    float elapsedTime;

    public void SetUp(RingProductionUnit ringProductionUnit) {
        this.ringProductionUnit = ringProductionUnit;
        this.gameObject.name = ringProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {ringProductionUnit.name} for {ringProductionUnit.costs} rings.";
    }
	
    public int RingMakerAmount {
        get => PlayerPrefs.GetInt(this.ringProductionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.ringProductionUnit.name, value);
            UpdateRingPressAmountLabel();
        }
    }

    void UpdateRingPressAmountLabel() {
        this.ringAmountText.text = this.RingMakerAmount.ToString($"0 {this.ringProductionUnit.name}");
    }

    void Start() {
        UpdateRingPressAmountLabel();
        colors = new ColorBlock();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.ringProductionUnit.productionTime) {
            ProduceRing();
            FloatingEarnText();
            this.elapsedTime -= this.ringProductionUnit.productionTime;
        }
        ChangeColorStateButton();
    }
    void ProduceRing() {
        var ring = FindObjectOfType<Ring>();
        ring.RingAmount += this.ringProductionUnit.productionAmount * this.RingMakerAmount;
        
    }
    void FloatingEarnText()
    {
        floatingEarningsPrefab.text = (this.ringProductionUnit.productionAmount * this.RingMakerAmount).ToString();
        var earnTextInstance = Instantiate(floatingEarningsPrefab, this.transform.position, quaternion.identity);
        earnTextInstance.transform.SetParent(this.transform);
    }
    public void BuyRingProductionUnit() {
        var ring = FindObjectOfType<Ring>();
        if (ring.RingAmount >= this.ringProductionUnit.costs) {
            ring.RingAmount -= (int)this.ringProductionUnit.costs;
            this.RingMakerAmount += 1;
            ringProductionUnit.costs *= 1.07f;
        }
    }
    public void ChangeColorStateButton()
    {
        var ring = FindObjectOfType<Ring>();
        colors = button.colors;
        colors.highlightedColor = ring.RingAmount >= this.ringProductionUnit.costs ? Color.green : Color.red;
        button.colors = colors;
    }
}