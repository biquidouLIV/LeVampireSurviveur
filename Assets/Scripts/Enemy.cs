
using UnityEngine;

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
    


    private void Update()
    {
        if(target != null) destination = target.position;
        Move();
        if (Vector3.Distance(destination, transform.position) < 0.1f) Die();
    }

    private void Move()
    {
        transform.Translate((destination - transform.position).normalized * speed);
    }

    private void Die()
    {
        if(Random.Range(0f,1f) < xpDropRate) Instantiate(coin);
        EnemyManager.instance.AddToPool(this.gameObject);
    }
}
