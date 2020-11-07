using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.ResourceProduction{
    public class ResourceProducer : MonoBehaviour {
        public Data Data;
        public Text amountText;
        public FloatingTextScript popupPrefab;
        public Purchasable amount;
        public Purchasable upgrade;
        float elapsedTime;
        public void SetUp(Data data) {
            this.Data = data;
            this.gameObject.name = data.name;
            this.amount.SetUp(this.Data, data.costsResource, "factory");
            this.upgrade.SetUp(this.Data, data.costsResource, "level");
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
            if (this.elapsedTime >= this.Data.productionTime) {
                Produce();
                this.elapsedTime -= this.Data.productionTime; // DO NOT SET TO ZERO HERE
            }
        }
        void UpdateTitleLabel() {
            this.amountText.text = $"{this.amount.Amount}x {this.Data.name} Level {this.upgrade.Amount}";
        }
        void Produce() {
            if (this.amount.Amount == 0)
                return;
            this.Data.productionResource.Amount += Mathf.RoundToInt(CalculateProductionAmount());
            var instance = Instantiate(this.popupPrefab, this.transform);
            instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()} {this.Data.productionResource.name}";
        }
        float CalculateProductionAmount() {
            return this.Data.GetProductionAmount(this.upgrade.Amount) * this.amount.Amount;
        }
    }
}