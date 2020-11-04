using System;
using UnityEngine;

[CreateAssetMenu]
public class RingProductionData : ScriptableObject
{
    [SerializeField] int costs = 100;
    [SerializeField] float costMultiplier = 1.1f;
    public float productionTime = 1f;
    [SerializeField] int productionAmount = 1;
    [SerializeField] float productionMultiplier = 1.05f;
    public int GetActualCosts(int amount) {
        var result = this.costs * Mathf.Pow(this.costMultiplier, amount);
        return Mathf.RoundToInt(result);
    }
    public int GetProductionAmount(int upgradeAmount) {
        var result = this.productionAmount * Mathf.Pow(this.productionMultiplier, upgradeAmount);
        return Mathf.RoundToInt(result);
    }
}
/*  Make your PurchasableProducts upgradable.
    The upgrade costs increase just as much as the PurchaseCosts for PurchasableProducts.
    Each upgrade increases the amount of all gold produced by this kind of GoldProduction by 5%.     */