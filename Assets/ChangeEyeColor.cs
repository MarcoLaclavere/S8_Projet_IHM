using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEyeColor : MonoBehaviour
{

    public GameObject[] Eyes ;

    public Color[] colors = new Color[] {Color.black, Color.green, Color.blue, Color.red, Color.yellow, Color.white, Color.cyan, Color.magenta, Color.grey, Color.gray};

    private int currentColor = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start() called");

        // Changer la couleur de chaque tête
        foreach (var eye in Eyes)
        {
            // Passer à la couleur suivante
            currentColor = (currentColor + 0) % colors.Length;
            GlobalCustomization.EyesIndex = currentColor;

            var renderer = eye.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[0];
            }
        }


        
    }

    public void setColor()
    {
        Debug.Log("SetColor() called");
        currentColor = (currentColor + 1) % colors.Length;
        // Changer la couleur de chaque tête
        foreach (var eye in Eyes)
        {
            // Passer à la couleur suivante
            

            var renderer = eye.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[currentColor];
            }
        }
        GlobalCustomization.EyesIndex = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
