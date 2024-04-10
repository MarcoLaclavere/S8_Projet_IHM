using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpinScript : MonoBehaviour
{

    public GameObject character;
  

  private int isSpining = 0;
    // Start is called before the first frame update

    void Start()
    {
        Animator anim = character.GetComponent<Animator>();
        if (anim != null) anim.enabled = false;
    }

    public void spin()
    {
        isSpining = 1;
    }

    public void unspin()
    {
        isSpining = 0;
    }



    // Update is called once per frame
    void Update()
    {


    if (isSpining == 1)
    {

        character.transform.Rotate(0, 3, 0);
    }

    }
}
