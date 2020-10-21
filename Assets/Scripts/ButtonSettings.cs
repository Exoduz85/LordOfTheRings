using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : MonoBehaviour
{
    public Button button;
    public ColorBlock colors;
    private void Start()
    {
        colors = button.colors;
    }
    public void Update()
    {
        button.colors = colors;
        ChangeColorStateButton();
    }
    public void ChangeColorStateButton()
    {
        colors.highlightedColor = GetComponent<Ring>().RingAmount >= 100 ? Color.green : Color.red;
    }
}