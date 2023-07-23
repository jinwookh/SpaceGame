using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float health = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            Debug.Log("적 충돌 health : " + health);
            collision.gameObject.SetActive(false);
        }
    }

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
        Destroy(this.gameObject);
    }

    public void Move()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        int randomNum = Random.Range(0, 2);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (randomNum == 0)
        {
            rb.isKinematic = false;
            rb.AddForce(Vector2.left * 50);
            Debug.Log("Moving left");
        }
        else
        {
            rb.isKinematic = false;
            rb.AddForce(Vector2.right * 50);
            Debug.Log("Moving right");
        }

        // Wait for a short duration before setting isKinematic back to true
        yield return new WaitForSeconds(0.5f);

        rb.isKinematic = true;
    }
}
