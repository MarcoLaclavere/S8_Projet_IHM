using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudScript : MonoBehaviour
{


    public void OnMouseDown()
    {
        // Action à exécuter lors du clic sur le modèle
        Debug.Log("Cloud Clicked");
        SceneManager.LoadScene("WE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
