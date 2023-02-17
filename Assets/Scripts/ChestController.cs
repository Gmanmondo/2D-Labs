using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator animator;
    private Keys keys;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        keys = GetComponent<Keys>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && keys.keyCount >= 1 && Input.GetKey(KeyCode.E))
        {
            animator.SetBool("OpenChest", true);
            keys.keyCount --;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("OpenChest", false);
    }
}
