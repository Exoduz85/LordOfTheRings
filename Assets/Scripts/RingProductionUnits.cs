using UnityEngine;
using UnityEngine.UI;

public class RingProductionUnits : MonoBehaviour {

    public RingProductionUnit[] ringProductionUnits;
    public Transform ringProductionUnitParent;
    public GameObject ringProductionUnitPrefab;

    void Start() {
        foreach (var productionUnit in this.ringProductionUnits) {
            var instance = Instantiate(this.ringProductionUnitPrefab, this.ringProductionUnitParent);
            instance.GetComponent<RingProductionUnitScript>().SetUp(productionUnit);
        }
    }
}