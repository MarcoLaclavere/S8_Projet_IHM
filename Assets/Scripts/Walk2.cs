using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walk2 : MonoBehaviour
{

    //animateur 
    public Animator animator;

    public GameObject pnj;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
            //vérifier si le pnj bouge
            bool isMoving = (Mathf.Abs(pnj.transform.position.x) > 0.1f || Mathf.Abs(pnj.transform.position.z) > 0.1f);
            animator.SetBool("IsWalking2", isMoving);


        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        // // Vérifier si le personnage se déplace
        // bool isMoving = (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f);
        // animator.SetBool("IsWalking2", isMoving);



        
    }
}

