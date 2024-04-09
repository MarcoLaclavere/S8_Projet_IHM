using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

            Cursor.visible = true; // Rendre le curseur visible
             Cursor.lockState = CursorLockMode.None; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
