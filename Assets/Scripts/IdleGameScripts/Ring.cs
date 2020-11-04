using UnityEngine;

[CreateAssetMenu]
public class Ring : ScriptableObject{
    public int ringAmountPerClick = 5;
    const string ringPlayerPrefKey = "Rings";
    public int RingAmount {
        get => PlayerPrefs.GetInt(ringPlayerPrefKey, 1);
        set => PlayerPrefs.SetInt(ringPlayerPrefKey, value);
    }
    public void ProduceGold() {
        this.RingAmount += this.ringAmountPerClick;
    }
}