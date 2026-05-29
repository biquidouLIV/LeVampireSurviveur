using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 mousePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = new Vector2();

            direction = mousePosition - gameObject.transform.position;
            direction.Normalize();

            rb.linearVelocity = direction;
            Debug.DrawLine(gameObject.transform.position, mousePosition);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
