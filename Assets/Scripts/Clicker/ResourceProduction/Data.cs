using Resources;
using UnityEngine;

namespace Clicker.ResourceProduction{
    [CreateAssetMenu(menuName="Clicker/ResourceProduction/Data", fileName="ResourceProductionData")]
    public class Data : ScriptableObject{
        [SerializeField]public int costs;
        public Resource costsResource;
        [SerializeField] float costMultiplier = 1.1f;
        public float productionTime = 1f;
        [SerializeField] int productionAmount = 1;
        public Resource productionResource;
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
}

/*
    Refactoring Suggestion: To clean up your code,
    it would be great to have a ResourceAmount class that has two fields:
    public int amount public Resource resource.
    It should be [System.Serializable].
    Now, in your GoldProductionData,
    use that class instead of having multiple fields for costs, 
    costsResource, upgradeCosts, upgradeCostsResource, productionAmount, productionAmountResource etc.
 */