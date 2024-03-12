using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeliverySystem : MonoBehaviour
{
    [Header("DELIVERY SYSTEM")]
    [SerializeField]float destroyDelay = 0.1f;
    [SerializeField]string[] planetsColors = new string[5];
    [SerializeField]string[] cratesColors = new string[5];
    [SerializeField]Color32[] colors = new Color32[5];
    [SerializeField]bool[] hasCrate = new bool [5];
    [SerializeField]Color32 noCrate = new Color32(0,0,0,0);
    
    [Header("DELIVERY SOUND FX")]
    [SerializeField]AudioClip pickUpSoundClip;
    [SerializeField][Range(0f,1f)]float pickUpSoundClipVolume = 1f;
    [SerializeField]AudioClip deliverySoundClip;
    [SerializeField][Range(0f, 1f)] float deliverySoundClipVolume = 1f;
    bool hasAlreadyACrate;
    public bool isGameWin;
    SpriteRenderer spriteRenderer;
    int deliveryCounter;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noCrate;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < 5; i++)
        {
            if (other.tag == cratesColors[i] && !hasCrate[i] && !hasAlreadyACrate)
            {
                hasCrate[i] = true;
                hasAlreadyACrate = true;
                SoundFXManager.instance.PlaySoundFXClip(pickUpSoundClip, transform, pickUpSoundClipVolume);
                Debug.Log("Cassa Raccolta!");
                spriteRenderer.color = colors[i];
                Destroy(other.gameObject, destroyDelay);
            }

            if (other.tag == planetsColors[i] && hasCrate[i])
            {
                Debug.Log("Cassa Consegnata!");
                hasCrate[i] = false;
                hasAlreadyACrate = false;
                SoundFXManager.instance.PlaySoundFXClip(deliverySoundClip, transform, deliverySoundClipVolume);
                spriteRenderer.color = noCrate;
                deliveryCounter++;
                Debug.Log(deliveryCounter);
            }
        }
//################ WIN CONDITION #######################
        if (deliveryCounter == 5)
        {   
            isGameWin = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("HAI DELIVERATO!");
        }    
    }
}