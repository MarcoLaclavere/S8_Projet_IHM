using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passiveSpin : MonoBehaviour
{

    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        model.transform.Rotate(0, 0.3f, 0);
        
    }
}
