﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;
    public float floatForce;
    private float gravityModifier = 1.0f;
    private Rigidbody playerRb;
    
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;
    private bool isLowenough = true;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 17.0)
            isLowenough = false;
        else
            isLowenough = true;

            // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) && !gameOver && isLowenough)
            {
                if (isLowenough)
                    playerRb.AddForce(Vector3.up * floatForce);
            }
       
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if(other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 200);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

}
