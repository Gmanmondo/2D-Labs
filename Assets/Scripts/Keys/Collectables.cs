using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : MonoBehaviour
{
    [SerializeField] protected int collectableCount;

    protected virtual void DestroyCollectable()
    {
        Destroy(gameObject);
    }
}