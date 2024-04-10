using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalCustomization : MonoBehaviour
{

    

    public GameObject[] bodies;
    public GameObject[] heads;

    public GameObject Eyes;

    public GameObject face;
    public Color[] colorsHair;
    public Color[] colorsEyes;
    public Color[] colorsSkin; 


     public static int BodyIndex { get; set; } = 0; // Initialisé à 0 par défaut
     
        public static int HeadIndex { get; set; } = 0; // Initialisé à 0 par défaut     
        public static int EyesIndex { get; set; } = 0; // Initialisé à 0 par défaut
        public static int HairColorIndex { get; set; } = 0; // Initialisé à 0 par défaut

        public static int SkinColor { get; set; } = 0; // Initialisé à 0 par défaut
        private static Dictionary<Currency, int> Currencies = new Dictionary<Currency, int>();
        // Start is called before the first frame update
        void Start()
        {

            for (int i = 0; i < bodies.Length; i++)
            {
                bodies[i].SetActive(false);
            }

            bodies[BodyIndex].SetActive(true);







            for (int i = 0; i < heads.Length; i++)
            {
                heads[i].SetActive(false);
            }



            heads[HeadIndex].SetActive(true);

            // Changer la couleur de la tete
            var renderer = face.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colorsSkin[SkinColor];
            }

            // Changer la couleur des cheveux
            foreach (var head in heads)
            {
                // Passer à la couleur suivante
                var rendererHair = head.GetComponent<Renderer>();
                if (rendererHair != null)
                {
                    rendererHair.material.color = colorsHair[HairColorIndex];
                }
            }

            // Changer la couleur des yeux
            var rendererEyes = Eyes.GetComponent<Renderer>();
            if (rendererEyes != null)
            {
                rendererEyes.material.color = colorsEyes[EyesIndex];
            }




        
        }

        // Update is called once per frame
        void Update()
        {

                    if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("planetsMenu");
            }



        }

        public static int AddCurrency(CurrencyAmount Ca)
        {
        if(Currencies.ContainsKey(Ca.currency))
        {
            Currencies[Ca.currency] += Ca.amount;
        }
        else
        {
            Currencies.Add(Ca.currency, Ca.amount);
        }
            return Currencies[Ca.currency];
    }
    public static int getCurrency(Currency currency)
    {
        return Currencies[currency];
    }
    public int getMoney()
    {
        if (Currencies.ContainsKey(Currency.Money)) { return 0; }
        return Currencies[Currency.Money];
    }
}