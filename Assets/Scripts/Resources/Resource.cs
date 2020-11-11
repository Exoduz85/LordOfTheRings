using UnityEngine;

namespace Resources{
    [CreateAssetMenu]
    public class Resource : ScriptableObject{
        public int resourceAmountPerClick = 5;
        public Color color;
        public int Owned {
            get => PlayerPrefs.GetInt(this.name, 1);
            set => PlayerPrefs.SetInt(this.name, value);
        }
        public void Produce() {
            this.Owned += this.resourceAmountPerClick;
        }
    }
}