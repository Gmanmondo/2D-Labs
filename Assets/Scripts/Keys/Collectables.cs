using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private CollectableType collectableType = new CollectableType();
    [SerializeField] private Collectable collectable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectable == Collectable.Health) {
                print("You picked up health!");
                DestroyCollectable();
            }
            else if (collectable == Collectable.Keys) {
                print("You picked up a key!");
                DestroyCollectable();
            }
        }
    }

    void DestroyCollectable()
    {
        Destroy(gameObject);
    }
}