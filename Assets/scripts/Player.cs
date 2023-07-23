using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float health = 100.0f;

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("주인공 사망 health : " + health);
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the reverse velocity to cancel the collision effect
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 reverseVelocity = -rb.velocity;
        // Apply the reverse velocity to cancel the collision effect
        rb.velocity = reverseVelocity;
        // You can also set the Rigidbody2D's angular velocity to zero if needed
        rb.angularVelocity = 0f;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("주인공 충돌 health : " + health);
            TakeDamage(10);
            Destroy(collision.gameObject);
        }
    }
}
