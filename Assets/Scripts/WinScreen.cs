using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{   
    DeliverySystem deliverySystem;
    public bool isWinScreenActive;
    void Start()
    {
        deliverySystem = FindObjectOfType<DeliverySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deliverySystem.isGameWin)
        {
            isWinScreenActive = true;
        }
    }
}
