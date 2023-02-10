using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Collectables
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void DestroyCollectable()
    {
        base.DestroyCollectable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyCollectable();
        }
    }
}
