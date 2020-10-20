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
    public int pressTimer;
    private float timeBetweenPress;

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
        timeBetweenPress = pressTimer;
        UpdatePressAmountLabel();
        colors = goldPressButton.colors;
    }

    void UpdatePressAmountLabel() {
        this.goldPressAmountText.text = this.AmountOfGoldPressers.ToString("0 gold pressers");
        this._amountOfGoldPressers = AmountOfGoldPressers;
    }
    void Update()
    {
        goldPressButton.colors = colors;
        TimeCounterAddGold();
    }

    private void TimeCounterAddGold()
    {
        if (timeBetweenPress <= 0)
        {
            GetComponent<Gold>().GoldAmount = goldPressWorth * _amountOfGoldPressers;
            timeBetweenPress = pressTimer;
        }
        else
        {
            timeBetweenPress -= Time.deltaTime;
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
