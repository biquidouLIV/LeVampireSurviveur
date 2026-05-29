using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector3 mousePosition;
    [SerializeField] private float speed;
    [SerializeField] private int hp = 10;
    private int xp = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = new Vector2();

            direction = mousePosition - gameObject.transform.position;
            if (direction.magnitude < 0.1f) direction = Vector2.zero;
            direction.Normalize();

            rb.linearVelocity = direction * speed;
            Debug.DrawLine(gameObject.transform.position, mousePosition);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void GiveXp(int _xp)
    {
        xp += _xp;
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(TakeDamageColor());
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("plus de vie");
            Die();
        }
    }

    private IEnumerator TakeDamageColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        Debug.Log("die");
        GameManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}