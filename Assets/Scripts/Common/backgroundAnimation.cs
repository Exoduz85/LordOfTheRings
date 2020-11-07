using UnityEngine;
using UnityEngine.UI;

namespace Common{
    public class backgroundAnimation : MonoBehaviour{
        public Image image;
        public Sprite[] sprites;
        public int index = 0;
        public float framesPerSecond = 0.1f;
        public float elapsedTime;

        private void Start()
        {
            image = this.GetComponent<Image>();
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;
            if (framesPerSecond < elapsedTime)
            {
                if (index >= sprites.Length)
                {
                    index = 0;
                }
                image.sprite = sprites[index];
                index++;
                elapsedTime = 0;
            }
        }
    }
}
