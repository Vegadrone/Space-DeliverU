using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    FuelSystem fuelSystem;
    public bool isGameOverScreenActive;
    void Start()
    {
        fuelSystem = FindObjectOfType<FuelSystem>();
    }

    void Update()
    {
        UnityEngine.Debug.LogWarning("Questo è il booleano FUORI PRIMA del check ed é:"+ " " + isGameOverScreenActive);
        if (fuelSystem.isGameLost)
        {
            isGameOverScreenActive = true;
            UnityEngine.Debug.LogWarning("Questo è il booleano DOPO del check ed é:" + " " + isGameOverScreenActive);
        }
        UnityEngine.Debug.LogWarning("Questo è il booleano FUORI DOPO il check ed é:" + " " + isGameOverScreenActive);
    }  
}
