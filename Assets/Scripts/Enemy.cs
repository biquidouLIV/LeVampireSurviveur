
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private Vector3 destination;
    [SerializeField] private GameObject coin;
    
    
    [Header("stats")]
    [Range(0f,1f)] [SerializeField] private float xpDropRate;
    [SerializeField] private float speed;
    [SerializeField] private int damage = 1;
    [SerializeField] private int hp = 100;


    private void Start()
    {
        StartCoroutine(ActiveShadow());
    }

    private IEnumerator ActiveShadow()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<ShadowCaster2D>().trimEdge = 0.1f;
        GetComponent<ShadowCaster2D>().trimEdge = 0.01f;

    }
    private void Update()
    {
        if(target != null) destination = target.position;
        Move();
        if (Vector3.Distance(destination, transform.position) < 0.1f) Die();
    }

    private void Move()
    {
        transform.Translate((destination - transform.position).normalized * speed * Time.timeScale);
    }

    private void Die()
    {
        if(Random.Range(0f,1f) < xpDropRate) Instantiate(coin);
        EnemyManager.instance.AddToPool(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.TakeDamage(damage);
        }
        Die();
    }
}
