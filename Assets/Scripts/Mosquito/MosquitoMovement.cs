using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float vDamage = 20f;
    Vector3 TargetPosition; // player position
    private Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        TargetPosition = Vector3.zero; // player position
        movement = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = TargetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveMosquito(movement);
    }

    void MoveMosquito(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<BaseStatus>() != null) {
                collision.gameObject.GetComponent<BaseStatus>().TakeDamage(vDamage);
                gameObject.GetComponent<BaseStatus>().Die();
            }
        }
    }
}
