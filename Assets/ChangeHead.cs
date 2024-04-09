using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHead : MonoBehaviour
{


    public GameObject[] heads;
   // [SerializeField] private Button button;
    private int currenthead = 0;

    public void NextHead()
    {

        Debug.Log("NextHead() called");

        // Disable the current head
        heads[currenthead].SetActive(false);

        // Increment the index to the next head
        currenthead = (currenthead + 1) % heads.Length;

        // Enable the new current head
        heads[currenthead].SetActive(true);
        GlobalCustomization.HeadIndex = currenthead;
    }
        

    // private void Awake()
    // {
    //     button.onClick.AddListener(()=>{
    //         NextHead();
    //         Debug.Log("Button clicked");
    //     });
        
    // }




    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Start() called");
        for (int i = 1; i < heads.Length; i++)
        {
            heads[i].SetActive(false);
        }

        heads[0].SetActive(true);
        GlobalCustomization.HeadIndex = 0;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
