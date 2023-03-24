using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectable
{
    Health, Keys
};

public class CollectableType
{
    [SerializeField] private Collectable collectableType;

    public CollectableType()
    {
        Debug.Log($"This is a new collectable");
    }
}
