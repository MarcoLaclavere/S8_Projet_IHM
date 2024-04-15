using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCustomization : MonoBehaviour
{

    

    public GameObject[] bodies;
    public GameObject[] heads;

    public GameObject Eyes;

    public GameObject face;
    public Color[] colorsHair;
    public Color[] colorsEyes;
    public Color[] colorsSkin;



        void Start()
        {

        



            for (int i = 0; i < bodies.Length; i++)
            {
                bodies[i].SetActive(false);
            }

            //mettre un corps aléatoire
            int BodyIndex = Random.Range(0, bodies.Length);



            bodies[BodyIndex].SetActive(true);







            for (int i = 0; i < heads.Length; i++)
            {
                heads[i].SetActive(false);
            }

            //mettre une tête aléatoire
            int HeadIndex = Random.Range(0, heads.Length);




            heads[HeadIndex].SetActive(true);

            // Changer la couleur de la tete
            var renderer = face.GetComponent<Renderer>();
            if (renderer != null)
            {

                //mettre une couleur de peau aléatoire
                int SkinColor = Random.Range(0, colorsSkin.Length);
                renderer.material.color = colorsSkin[SkinColor];
            }

            // Changer la couleur des cheveux
            foreach (var head in heads)
            {
                // Passer à la couleur suivante
                var rendererHair = head.GetComponent<Renderer>();
                if (rendererHair != null)
                {

                    //mettre une couleur de cheveux aléatoire
                    int HairColorIndex = Random.Range(0, colorsHair.Length);
                    rendererHair.material.color = colorsHair[HairColorIndex];
                }
            }

            // Changer la couleur des yeux
            var rendererEyes = Eyes.GetComponent<Renderer>();
            if (rendererEyes != null)
            {
                //mettre une couleur des yeux aléatoire
                int EyesIndex = Random.Range(0, colorsEyes.Length);
                
                rendererEyes.material.color = colorsEyes[EyesIndex];
            }




        
        }

        // Update is called once per frame
        void Update()
        {



        }



}
