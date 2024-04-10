using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIScript : MonoBehaviour
{

    public static UIScript UiScript;

    public TextMeshProUGUI moneyDisplay;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(GlobalCustomization.getMoney().ToString());
        if(UIScript.getInstance() == null)
        {
            UIScript.UiScript = this;
        }
        else
        {
            Destroy(this);
        }
        moneyDisplay.text = "" + GlobalCustomization.getMoney().ToString();
        
    }

    public static UIScript getInstance()
    {
        return UiScript;
    }

    // Update is called once per frame
    void UpdateMoney(int val)
    {

        moneyDisplay.text = "" + val.ToString();
        
    }
    [ContextMenu("test")]
    public void test(){
        Debug.Log("Test");
        
    }
}
