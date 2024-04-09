using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeBody : MonoBehaviour





{


    public GameObject[] bodies;

    private int currentbody = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < bodies.Length; i++)
        {
            bodies[i].SetActive(false);
        }

        bodies[0].SetActive(true);
        GlobalCustomization.BodyIndex = 0;
        
    }

    public void NextBody()
    {
        // Disable the current head
        bodies[currentbody].SetActive(false);

        // Increment the index to the next head
        currentbody = (currentbody + 1) % bodies.Length;

        // Enable the new current head
        bodies[currentbody].SetActive(true);
        GlobalCustomization.BodyIndex = currentbody;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
