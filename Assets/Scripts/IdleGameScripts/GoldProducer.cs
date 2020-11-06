using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
   
    public GoldProductionData goldProductionData;
    public Text goldAmountText;
    public FloatingTextScript popupPrefab;
    public Gold gold;
    public Purchasable amount;
    public Purchasable upgrade;
    float elapsedTime;
    public void SetUp(GoldProductionData goldProductionUnit) {
        this.goldProductionData = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.amount.SetUp(goldProductionData, this.gold, "Count");
        this.upgrade.SetUp(goldProductionData, this.gold, "Level");
    }
    public void Purchase() => this.amount.Purchase();
    public void Upgrade() => this.upgrade.Purchase();
    void Update() {
        UpdateProduction();
        UpdateTitleLabel();
        this.amount.Update();
        this.upgrade.Update();
    }
    void UpdateProduction() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.goldProductionData.productionTime) {
            ProduceGold();
            this.elapsedTime -= this.goldProductionData.productionTime; // DO NOT SET TO ZERO HERE
        }
    }
    void UpdateTitleLabel() {
        this.goldAmountText.text = $"{this.amount.Amount}x {this.goldProductionData.name} Level {this.upgrade.Amount}";
    }
    void ProduceGold() {
        if (this.amount.Amount == 0)
            return;
        this.gold.GoldAmount += Mathf.RoundToInt(CalculateProductionAmount());
        var instance = Instantiate(this.popupPrefab, this.transform);
        instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()}";
    }
    float CalculateProductionAmount() {
        return this.goldProductionData.GetProductionAmount(this.upgrade.Amount) * this.amount.Amount;
    }
}