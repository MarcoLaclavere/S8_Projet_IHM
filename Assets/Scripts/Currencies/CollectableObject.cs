using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{

    public Collider collider;
    public int gainzz = 1;
    public float respawn = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            GlobalCustomization.UpdateMoney(gainzz);

            if (respawn != 0)
            {
                gameObject.SetActive(false);
                Invoke(nameof(Respawn), respawn);
            }
            else { Destroy(gameObject); }
            

        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
    }

}
