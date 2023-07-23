using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    public abstract void DestroyAfterTime();
    public abstract void ApplyItem();
    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        DestroyAfterTime();
    }
}

public interface IEffect
{
    void GetOpaque();
}
