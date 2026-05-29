using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    private Queue<GameObject> EnemyPool = new Queue<GameObject>();
    

    [SerializeField] private GameObject EnemyPrefab;
     
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            SpawnEnemy();
        }
    }


    private GameObject GetFromPool()
    {
        if (EnemyPool.Count == 0)
        {
            return Instantiate(EnemyPrefab);
        }
        return EnemyPool.Dequeue();
    }

    public void AddToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        EnemyPool.Enqueue(enemy);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = GetFromPool();
        enemy.GetComponent<Enemy>().destination = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));    //a retirer quand on a le player
        enemy.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));                   //peut etre faire en sorte que ca spawn pas trop proche du player
        enemy.SetActive(true);
    }
    
    
    
    
    
    
}
