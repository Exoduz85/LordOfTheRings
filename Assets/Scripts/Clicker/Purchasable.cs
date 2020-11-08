using System;
using Clicker.ResourceProduction;
using Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker{
    [Serializable]
    public class Purchasable{
        public Text buttonLabel;
        ResourceProduction.Data data;
        Resource resource;
        string productId;
        bool IsAffordable => this.resource.Amount >= this.data.GetActualCosts(this.Amount);
        public int Amount {
            get => PlayerPrefs.GetInt(this.resource.name+"_"+this.productId, 0);
            private set => PlayerPrefs.SetInt(this.resource.name+"_"+this.productId, value);
        }

        public void SetUp(ResourceProduction.Data data, string productId) {
            this.data = data;
            this.resource = data.costs.resourceType;
            this.productId = productId;
            this.buttonLabel.text = $"Add {productId} for {data.GetActualCosts(this.Amount)} {this.resource.name}";
        }

        public void Purchase() {
            if (!this.IsAffordable) 
                return;
            this.resource.Amount -= this.data.GetActualCosts(this.Amount);
            this.Amount += 1;
            this.buttonLabel.text = $"Add {this.productId} for {this.data.GetActualCosts(this.Amount)} {this.resource.name}";
        }

        public void Update() => UpdateTextColor();
        void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.green : Color.red;
    }
}