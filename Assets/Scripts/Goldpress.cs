using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Goldpress : MonoBehaviour
{
    public TextMeshProUGUI goldPressAmountText;
    public Button goldPressButton;
    private ColorBlock colors;
    private int goldPressWorth = 1;
    private int _amountOfGoldPressers;
    private float elapsedTime;
    private float productionTime = 1f;

    public int AmountOfGoldPressers
    {
        get => PlayerPrefs.GetInt("GoldPressers", 0);
        set
        {
            this._amountOfGoldPressers = value;
            PlayerPrefs.SetInt("GoldPressers", _amountOfGoldPressers);
            UpdatePressAmountLabel();
        }
    }
    private void Start()
    {
        UpdatePressAmountLabel();
        colors = goldPressButton.colors;
    }

    void UpdatePressAmountLabel() {
        this.goldPressAmountText.text = this.AmountOfGoldPressers.ToString("Ringpresser: 0");
        this._amountOfGoldPressers = AmountOfGoldPressers;
    }
    void Update()
    {
        goldPressButton.colors = colors;
        TimeCounterAddGold();
        ChangeColorStateButton();
    }

    private void TimeCounterAddGold()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.productionTime)
        {
            GetComponent<Gold>().GoldAmount = goldPressWorth * _amountOfGoldPressers;
            this.elapsedTime -= this.productionTime;
        }
    }

    public void BuyGoldPresser()
    {
        if (GetComponent<Gold>().GoldAmount <= 100)
        {
            Debug.Log("You dont have enough money for that!");
        }
        else
        {
            GetComponent<Gold>().GoldAmount = -100;
            AmountOfGoldPressers++;
        }
    }

    public void ChangeColorStateButton()
    {
        colors.highlightedColor = GetComponent<Gold>().GoldAmount >= 100 ? Color.green : Color.red;
    }
}
