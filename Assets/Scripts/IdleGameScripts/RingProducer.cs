using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class RingProducer : MonoBehaviour {
    public RingProductionData RingProductionData;
    public Text ringAmountText;
    public Text purchaseButtonLabel;
    public Text upgradeButtonLabel;
    public FloatingTextScript popupPrefab;
    public Button button;
    public Button upgradeButton;
    public ColorBlock colors;
    public ColorBlock upgradeColors;
    public Ring ring;
    float elapsedTime;
    bool IsAffordable => this.ring.RingAmount >= this.RingProductionData.GetActualCosts(this.Amount);
    bool IsUpgradeAffordable => this.ring.RingAmount >= this.RingProductionData.GetActualCosts(this.UpgradeAmount);
    public void SetUp(RingProductionData ringProductionUnit) {
        this.RingProductionData = ringProductionUnit;
        this.gameObject.name = ringProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase for {this.RingProductionData.GetActualCosts(this.Amount)}";
        this.upgradeButtonLabel.text = $"Upgrade for {this.RingProductionData.GetActualCosts(this.UpgradeAmount)}";
    }
    public int Amount {
        get => PlayerPrefs.GetInt(this.RingProductionData.name, 0); // recommend not to use same key for float/int etc
        set {
            PlayerPrefs.SetInt(this.RingProductionData.name, value);
            UpdateRingPressAmountLabel();
        }
    }
    string UpgradeAmountPlayerPrefKey => $"{this.RingProductionData.name}_Upgrade";

    int UpgradeAmount {
	    get => PlayerPrefs.GetInt(this.UpgradeAmountPlayerPrefKey, 0);
	    set {
		    PlayerPrefs.SetInt(this.UpgradeAmountPlayerPrefKey, value);
		    UpdateTitleLabel();
	    }
    }
    public void Upgrade() {
	    if (this.IsUpgradeAffordable) {
		    this.ring.RingAmount -= this.RingProductionData.GetActualCosts(this.UpgradeAmount);
		    this.UpgradeAmount += 1;
		    this.upgradeButtonLabel.text = $"Upgrade for {this.RingProductionData.GetActualCosts(this.UpgradeAmount)}";
	    }
    }
    public void Purchase() {
        if (this.IsAffordable) {
            ring.RingAmount -= this.RingProductionData.GetActualCosts(this.Amount);
            this.Amount += 1;
            this.purchaseButtonLabel.text = $"Purchase for {this.RingProductionData.GetActualCosts(this.Amount)}";
        }
    }
    void UpdateRingPressAmountLabel() {
        this.ringAmountText.text = this.Amount.ToString($"0 {this.RingProductionData.name}");
    }
    void Start() {
        UpdateRingPressAmountLabel();
        colors = new ColorBlock();
        upgradeColors = new ColorBlock();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.RingProductionData.productionTime) {
            if (this.Amount != 0) {
                ProduceRing();
            }
            this.elapsedTime -= this.RingProductionData.productionTime;
        }
        ChangeColorStateButton();
    }
    void UpdateTitleLabel() {
	    this.ringAmountText.text = $"{this.Amount}x {this.RingProductionData.name} Level {this.UpgradeAmount}";
    }
    void ProduceRing() {
	    if (this.Amount == 0)
		    return;
	    this.ring.RingAmount += Mathf.RoundToInt(CalculateProductionAmount());
	    var instance = Instantiate(this.popupPrefab, this.transform);
	    instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()}";
    }
    float CalculateProductionAmount() {
	    return this.RingProductionData.GetProductionAmount(this.UpgradeAmount) * this.Amount;
    }
    public void ChangeColorStateButton() {
        colors = button.colors;
        colors.highlightedColor = this.IsAffordable ? Color.green : Color.red;
        button.colors = colors;
        upgradeColors = upgradeButton.colors;
        upgradeColors.highlightedColor = this.IsUpgradeAffordable ? Color.green : Color.red;
        upgradeButton.colors = upgradeColors;
    }
}