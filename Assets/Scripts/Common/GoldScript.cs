using UnityEngine;
using UnityEngine.UI;

namespace Common{
    public class GoldScript : MonoBehaviour
    {
        public Text goldAmountText;
        public Image closetChest;
        public Image openChest;
        public int amountOfGold;

        private void Update()
        {
            updateGoldAmount(amountOfGold);
        }

        void updateGoldAmount(int amountGold)
        {
            goldAmountText.text = amountGold.ToString("Gold: 0");
        }

        public void setGold(int goldcoins)
        {
            amountOfGold += goldcoins;
        }
    }
}
