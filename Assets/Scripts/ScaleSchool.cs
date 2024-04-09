using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sclaschool : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject model;
    public Vector3 flattenedScale = new Vector3(1, 1, 0.5f);
    void Start()
    {

        model.transform.localScale = flattenedScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
