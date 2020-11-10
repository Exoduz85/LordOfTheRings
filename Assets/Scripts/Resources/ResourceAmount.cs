using UnityEngine;

namespace Resources{
    [System.Serializable]

    public class ResourceAmount {
        public int amount;
        public Resource resource;

        public override string ToString() {
            return $"{this.amount} {this.resource.name}";
        }

        // TODO: implement correctly
        public bool IsAffordable => false;
		
        // TODO: implement correctly
        public void Create(){} // alternative names: add, deposit, increase
		
        // TODO: implement correctly
        public void Consume(){} // alternative names: subtract, withdraw, decrease
		
        // TODO: Create a constructor
    }
}
