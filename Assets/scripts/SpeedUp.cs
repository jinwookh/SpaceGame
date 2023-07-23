using UnityEngine;

public class SpeedUp : Item
{
    public override void ApplyItem()
    {
        GameObject playerObj = GameObject.Find("Player");
        PlayerController controller = playerObj.GetComponent<PlayerController>();
        controller.speed *= 1.25f;

        DestroyThis();
    }

    public override void DestroyAfterTime()
    {
        Invoke("DestroyThis", 5.0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyItem();
        }
    }
}
