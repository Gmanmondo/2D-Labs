using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillboardController : MonoBehaviour
{
    public GameObject welcomeBoard;
    public GameObject selectPrompt;
    // Start is called before the first frame update
    void Start()
    {
        welcomeBoard.SetActive(false);
        selectPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        selectPrompt.SetActive(true);
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
            selectPrompt.SetActive(false);
        }
    }
}