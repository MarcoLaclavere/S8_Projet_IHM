using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI moneyDisplay;

    private static UIManager UiManager;

    public static UIManager getInstance() { 
        return UiManager;
    }
    public void Start()
    {
        if (UIManager.getInstance() == null) { UIManager.UiManager = this; }
        else Destroy(this);


    }

    public void UpdateLapText(string message)
    {
        lapText.text = message;
    }
    public void UpdateMoney(int val)
    {
        if (moneyDisplay != null)
        {
            moneyDisplay.text = val.ToString();
        }
        else
        {
            moneyDisplay.text = val.ToString();
        }
    }
}
