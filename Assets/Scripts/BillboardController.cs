using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillboardController : MonoBehaviour
{
    public GameObject welcomeBoard;
    // Start is called before the first frame update
    void Start()
    {
        welcomeBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            welcomeBoard.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            welcomeBoard.SetActive(false);
        }
    }
}
