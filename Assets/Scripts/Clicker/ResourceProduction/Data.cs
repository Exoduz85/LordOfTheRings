using Resources;
using UnityEngine;

namespace Clicker.ResourceProduction{
    [CreateAssetMenu(menuName="Clicker/ResourceProduction/Data", fileName="ResourceProductionData")]
    public class Data : ScriptableObject{
        public ResourceAmount costs;
        public ResourceAmount produceResource;
        //[SerializeField]public int costs;
        //public Resource costsResource;
        [SerializeField] float costMultiplier = 1.1f;
        public float productionTime = 1f;
        //[SerializeField] int productionAmount = 1;
        //public Resource productionResource;
        [SerializeField] float productionMultiplier = 1.05f;
        public int GetActualCosts(int amount) {
            var result = this.costs.amount * Mathf.Pow(this.costMultiplier, amount);
            return Mathf.RoundToInt(result);
        }
        public int GetProductionAmount(int upgradeAmount) {
            var result = this.costs.amount * Mathf.Pow(this.productionMultiplier, upgradeAmount);
            return Mathf.RoundToInt(result);
        }
    }
}

/*
    Create a class named ResourceAmount that contains a reference to the
    Resource type and the amount (int). Use this within the Data
    ScriptableObject for costs and production amounts. Also use it as a return
    type for GetActualCosts() in the same class.
*/