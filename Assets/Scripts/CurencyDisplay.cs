using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurencyDisplay : MonoBehaviour
{

    public TextMeshProUGUI moneyDisplay;
    // Start is called before the first frame update
    void Start()
    {

        moneyDisplay.text = GlobalCustomization.getMoney().ToString();


        
    }

    // Update is called once per frame
    void Update()
    {

        moneyDisplay.text = GlobalCustomization.getMoney().ToString();
        
    }
}
