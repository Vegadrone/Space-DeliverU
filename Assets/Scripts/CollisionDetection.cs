using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [Header("COLLISION SOUND FX")]
    [SerializeField] AudioClip collisonSoundClip;
    [SerializeField][Range(0f, 1f)] float collisionSoundClipVolume = 1f;
    private float counterHit;
    
    private void OnCollisionEnter2D(Collision2D other)
    {   
        counterHit++;
        Debug.Log("BUMP!" + counterHit);
        SoundFXManager.instance.PlaySoundFXClip(collisonSoundClip, transform, collisionSoundClipVolume);
    }
}
