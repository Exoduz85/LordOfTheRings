using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class RingProductionData : ScriptableObject
{
    public string name = "RingProductionUnitScript";
    public string costKey = "costKey";
    public int productionAmount = 1;
    public float costs = 100;
    public float productionTime = 1f;
}