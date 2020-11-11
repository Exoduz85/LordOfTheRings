using UnityEngine;

namespace Resources{
    public class ResourceUISetup : MonoBehaviour{

        public Resource[] resources;
        public ResourceUI prefab;

        private void Start(){
            foreach (var resource in resources){
                var instance = Instantiate(this.prefab, this.transform);
                instance.SetUp(resource);
            }
        }
    }
}