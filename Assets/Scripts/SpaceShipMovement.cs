using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] float accelerationSpeed = 0.1f;
    [SerializeField] float steeringSpeed = 1f;
    [SerializeField] float friction = 0.5f;
    Vector2 steeringInput;
    Rigidbody2D myRb;
    bool isAccelerationPressed;
    float stearAmount;
    Transform engine;
    Transform engine2;
    ParticleSystem flame1;
    ParticleSystem flame2;
    AudioSource rocketSound;

    void Start()
    {
        engine = this.gameObject.transform.GetChild(0); 
        engine2 = this.gameObject.transform.GetChild(1);
        flame1 = engine.GetComponent<ParticleSystem>();
        flame2 = engine2.GetComponent<ParticleSystem>();
        myRb = GetComponent<Rigidbody2D>();  
        rocketSound = GetComponent<AudioSource>();
    } 
    //Prende il messaggio che il tasto invia all'azione di questo
    void OnAcceleration(InputValue value)
    {
        isAccelerationPressed = value.isPressed;
    }
    //Prende il messaggio che il tasto invia all'azione di questo
    void OnSteering(InputValue value)
    {
        steeringInput = value.Get<Vector2>();
    }
    void Steer()
    {
        stearAmount = steeringInput.x * steeringSpeed * Time.fixedDeltaTime;
        myRb.transform.Rotate(0f, 0f, stearAmount);
    }
    void Accelerate()
    {
        if (isAccelerationPressed)
        {
            //myRb.velocity = new Vector2(0f, accelerationSpeed);
            myRb.AddForce(transform.up * accelerationSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
            FuelSystem.instance.FuelConsuming();

            // In questa versione semplificata, quando il tasto di accelerazione viene rilasciato, 
            // verifichiamo se ciascun sistema di particelle è in riproduzione(isPlaying).
            // Se lo è, fermiamo direttamente la riproduzione utilizzando il metodo Stop.
            // Questo metodo è più diretto e dovrebbe risolvere il problema senza complicazioni aggiuntive.
            if (!flame1.isPlaying)
            {
                flame1.Play();
                rocketSound.Play();
            }
            if (!flame2.isPlaying)
            {
                flame2.Play();
                rocketSound.Play();
            }
            Debug.Log("premuto" + " " + isAccelerationPressed);
        }
        else
        {
            Vector2 oppositeVelocity = -myRb.velocity * friction;
            myRb.AddForce(oppositeVelocity, ForceMode2D.Force); ;
            if (flame1.isPlaying)
            {
                flame1.Stop();
                rocketSound.Stop();
            }
            if (flame2.isPlaying)
            {
                flame2.Stop();
                rocketSound.Stop();
            }
            Debug.Log("rilascio" + " " + isAccelerationPressed);
        }
    }
    void FixedUpdate()
    {
        Steer();
        Accelerate();
    }
}
