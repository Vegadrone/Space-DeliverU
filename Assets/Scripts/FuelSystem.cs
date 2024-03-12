using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{   
    public static FuelSystem instance;

    [Header("FUEL SYSTEM")]
    string fuel = "Fuel";
    [SerializeField]float fuelTankCounter = 1000f;
    [SerializeField]float fuelTankRefill = 100f;
    [SerializeField]float destroyDelay = 0.1f;

    [Header("FUEL SOUND FX")]
    [SerializeField] AudioClip fuelPickUpSoundClip;
    [SerializeField][Range(0f, 1f)] float fuelPickUpSoundClipVolume = 1f;

    public bool isGameLost;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public bool FuelConsuming()
    {
        fuelTankCounter--;
        Debug.LogWarning(fuelTankCounter);

        if (fuelTankCounter == 0f)
        {   
            isGameLost = true;
            Debug.LogWarning("isGameLost in FuelSystem DENTRO il check ed é:" + " " + isGameLost);
        }
        //Debug.LogWarning("isGameLost in FuelSystem DOPO il check ed é:" + " " + isGameLost);
        return isGameLost;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == fuel)
        {
            SoundFXManager.instance.PlaySoundFXClip(fuelPickUpSoundClip, transform, fuelPickUpSoundClipVolume);
            Destroy(other.gameObject, destroyDelay);
            fuelTankCounter += fuelTankRefill;
        }
    }
}
