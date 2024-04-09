using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   private float inputX;
   private float inputY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       inputY = Input.GetAxis("Vertical");
       inputX = Input.GetAxis("Horizontal");
       Debug.Log(inputX + "," + inputY);
        
    }
}
