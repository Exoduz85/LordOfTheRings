using UnityEngine;

public class RingProductionSetup : MonoBehaviour {

    public RingProductionData[] ringProductionUnits;
    public RingProducer ringProductionUnitPrefab;

    void Start() {
        foreach (var productionUnit in this.ringProductionUnits) {
            var instance = Instantiate(this.ringProductionUnitPrefab, this.transform);
            instance.SetUp(productionUnit);
        }
    }
}

