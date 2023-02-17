using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyController : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void IfKeyIsCollected()
    {
        gameObject.SetActive(true);
    }
}