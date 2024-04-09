using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToDiapo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMenu()
    {
        //Application.LoadLevel("SceneStart");
        SceneManager.LoadScene("SceneStart");
    }
}
