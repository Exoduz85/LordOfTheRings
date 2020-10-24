using UnityEngine;

public class RingProductionSetup : MonoBehaviour {

    public RingProductionData[] ringProductionUnits;
    public Transform ringProductionUnitParent;
    public GameObject ringProductionUnitPrefab;

    void Start() {
        foreach (var productionUnit in this.ringProductionUnits) {
            var instance = Instantiate(this.ringProductionUnitPrefab, this.ringProductionUnitParent);
            instance.GetComponent<RingProducer>().SetUp(productionUnit);
        }
    }
}