using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorFace : MonoBehaviour
{
    public GameObject[] faces;
    public Color[] colors = new Color[] {Color.yellow, Color.black, Color.white};
    private int currentColor = 0;
    public int cost = 5;

    public void setColor()
    {
        // if (!enabled)
        // {
        //     if (GlobalCustomization.getMoney() < cost) return;
        //     enabled = true;
        //     GlobalCustomization.UpdateMoney(-cost);
            
        // }
        Debug.Log("SetColor() called");
        currentColor = (currentColor + 1) % colors.Length;
        // Changer la couleur de chaque tête
        foreach (var face in faces)
        {
            // Passer à la couleur suivante
            

            var renderer = face.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colors[currentColor];
            }
            GlobalCustomization.SkinColor = currentColor;
        }
    }

        void Start()
    {
        Debug.Log("start() called");
        enabled = false;

        // Changer la couleur de chaque tête
        foreach (var face in faces)
        {
            // Passer à la couleur suivante
            currentColor = (currentColor + 1) % colors.Length;
            GlobalCustomization.SkinColor = currentColor;

            var renderer = face.GetComponent<Renderer>();
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
