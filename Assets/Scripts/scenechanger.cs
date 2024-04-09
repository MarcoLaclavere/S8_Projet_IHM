using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{

    public string sceneName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

        public void changeScene()
    {
        Debug.Log("changing scene");
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
