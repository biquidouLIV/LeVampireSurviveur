using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //GameManager.instance.player lui donner de l'xp
            Destroy(gameObject);
        }
    }
}
