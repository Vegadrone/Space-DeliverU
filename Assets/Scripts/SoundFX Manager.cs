using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    //Creiamo un singleton da poter richiamare in altre classi/oggetti
    //IMPORTANTE! I singleton devono essere solo UNO per SCENA
    //Possono essere richiamati in altre classi con NomeDelSingleton.instance.FunzioneCheMiServe
    //SoundFXManager.instance.PlaySoundFXCLip
   public static SoundFXManager instance;

   [SerializeField] private AudioSource soundFXObject;
   void Awake()
   {
        if (instance == null)
        {
            instance = this;
        }
   }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {   
        //Spawna un Game Object(quaternion.identity è = a rotazione del GO = 0) 
       AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        //Assegana un'audioClip
       audioSource.clip = audioClip;
       //Assegna Volume
        audioSource.volume = volume;
       //Fai partire il suono
        audioSource.Play();
       //prendi la lunghezza della clip audio
        float clipLength = audioSource.clip.length;
       //Distruggi l'oggetto una volta usato
       Destroy(audioSource.gameObject, clipLength);
    }
}
