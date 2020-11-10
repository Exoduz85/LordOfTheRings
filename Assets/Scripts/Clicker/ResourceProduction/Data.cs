using Resources;
using UnityEngine;

namespace Clicker.ResourceProduction{
    [CreateAssetMenu(menuName="Clicker/ResourceProduction/Data", fileName="ResourceProductionData")]
    public class Data : ScriptableObject {
        [SerializeField] ResourceAmount costs;
        [SerializeField] float costMultiplier = 1.1f;
        public float productionTime = 1f;
        [SerializeField] ResourceAmount production;
        [SerializeField] float productionMultiplier = 1.05f;
	
        public ResourceAmount GetActualCosts(int amount) {
            // TODO: no need for new () anymore when ResourceAmount is a struct
            var result = new ResourceAmount();
            result.resource = this.costs.resource;
            result.amount = Mathf.RoundToInt(this.costs.amount * Mathf.Pow(this.costMultiplier, amount));
            return result;
        }
	
        public ResourceAmount GetProductionAmount(int upgradeAmount, int unitCount) {
            // TODO: no need for new () anymore when ResourceAmount is a struct
            var result = new ResourceAmount();
            result.resource = this.production.resource;
            result.amount = Mathf.RoundToInt(this.production.amount * Mathf.Pow(this.productionMultiplier, upgradeAmount) * unitCount);
            return result;
        }
    }
}

//[SerializeField] int productionAmount = 1;
//public Resource productionResource;
//[SerializeField] int costs = 100;
//public Resource costsResource;
/*
    Create a class named ResourceAmount that contains a reference to the
    Resource type and the amount (int). Use this within the Data
    ScriptableObject for costs and production amounts. Also use it as a return
    type for GetActualCosts() in the same class.
*/