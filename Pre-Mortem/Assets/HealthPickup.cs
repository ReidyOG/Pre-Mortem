using System;
using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private int maxHealth;
    public int heal = 2;

    private void Start()
    {
        maxHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().health;
    }

    // On Trigger Event activates when the collider collides with another
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameObject player = collider.gameObject;
            player.GetComponent<PlayerHealth>().health += heal;
            if (player.GetComponent<PlayerHealth>().health > maxHealth)
            {
                player.GetComponent<PlayerHealth>().health = maxHealth;
            }
            gameObject.GetComponent<Renderer>().enabled = false;
//            gameObject.SetActive(false);
            StartCoroutine(reactivate());
        }
    }

    IEnumerator reactivate()
    {
        yield return new WaitForSeconds(20);
        gameObject.GetComponent<Renderer>().enabled = true;
//        gameObject.SetActive(true);
    }
}
