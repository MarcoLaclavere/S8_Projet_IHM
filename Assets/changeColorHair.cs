using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorHair : MonoBehaviour

{

    public GameObject[] heads;
    public Color[] colors = new Color[] {Color.green, Color.blue, Color.red, Color.yellow, Color.black, Color.white};

    private int currentColor = 0;

    // Start is called before the first frame update


    public void setColor()
    {
        Debug.Log("SetColor() called");
    currentColor = (currentColor + 1) % colors.Length;
    GlobalCustomization.HairColorIndex = currentColor;
        // Changer la couleur de chaque tête
        foreach (var head in heads)
        {
            // Passer à la couleur suivante
            

            var renderer = head.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[currentColor];
            }

        }
        GlobalCustomization.HairColorIndex = currentColor;
    }

        void Start()
    {
        Debug.Log("start() called");

        // Changer la couleur de chaque tête
        foreach (var head in heads)
        {
            // Passer à la couleur suivante
            currentColor = (currentColor + 0) % colors.Length;
            GlobalCustomization.HairColorIndex = currentColor;

            var renderer = head.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[0];
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
