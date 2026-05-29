using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Vector3 destination;
    [SerializeField] private float speed;

    private void Start()
    {
        //target = Transform du player
    }

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
        EnemyManager.instance.AddToPool(this.gameObject);
    }
    

    
}
