using UnityEngine;

[CreateAssetMenu]
public class Resource : ScriptableObject{
    public int resourceAmountPerClick = 5;
    string ResourcePlayerPrefKey => this.name + "_resource";
    public int ResourceAmount {
        get => PlayerPrefs.GetInt(ResourcePlayerPrefKey, 1);
        set => PlayerPrefs.SetInt(ResourcePlayerPrefKey, value);
    }
    public void ProduceResource() {
        this.ResourceAmount += this.resourceAmountPerClick;
    }
}