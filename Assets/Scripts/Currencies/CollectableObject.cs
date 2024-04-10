using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{

    public Collider collider;
    public List<CurrencyAmount> currencies;
    public float respawn = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            foreach(CurrencyAmount currency in currencies)
            {
                GlobalCustomization.AddCurrency(currency);
            }

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
