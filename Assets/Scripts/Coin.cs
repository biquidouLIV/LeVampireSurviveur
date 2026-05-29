using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    [SerializeField] private int minXP;
    [SerializeField] private int maxXP;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.GiveXp(Random.RandomRange(minXP,maxXP));
            Destroy(gameObject);
        }
    }
}
