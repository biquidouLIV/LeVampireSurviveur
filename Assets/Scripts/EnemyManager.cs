using System;
using System.Collections;
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

    [SerializeField] private Vector2 mapSize;
    [SerializeField] private float spawnDistance;
     
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        StartCoroutine(spawnLoop());
    }

    private IEnumerator spawnLoop()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(spawnLoop());
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
        bool goodSpawn = false;
        GameObject enemy = GetFromPool();
        enemy.GetComponent<Enemy>().target = GameManager.instance.player.transform;
        while(!goodSpawn)
        {

            Vector3 spawnPoint;
            spawnPoint = new Vector2(Random.Range(mapSize.x,mapSize.y), Random.Range(mapSize.x, mapSize.y));
            
            if (Vector3.Distance(spawnPoint, GameManager.instance.player.transform.position) < spawnDistance) continue;
            enemy.transform.position = spawnPoint;
            goodSpawn = true;
        }
        enemy.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GameManager.instance.player.transform.position,spawnDistance);
    }
}
