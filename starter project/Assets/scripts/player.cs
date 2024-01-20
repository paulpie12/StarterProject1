using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip losesound;
    public AudioClip hit;
    public float volume = 0.5f;

    public Text losescreen;
    public float forwardspeed = 1.0f;
    public float turnspeed = 1.0f;

    private Rigidbody2D rigidbody;
    private bool Forward;
    private float turnDirection;
    private bool lose = false;
    Renderer Ren;
    private void Awake()
    {
        losescreen.enabled = false;
        Ren = GetComponent<Renderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Forward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
            {
                turnDirection = 1.0f;
            }
             else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
             {
                turnDirection = -1.0f;
             }
            else
            {
                turnDirection = 0.0f;
            }
        if (lose == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(0);
            }
            losescreen.enabled = true;
            Invoke("pause", 1f);
        }
    }
    private void pause()
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(losesound, volume);
    }
    private void FixedUpdate()
    {
        if (Forward)
        {
            rigidbody.AddForce(this.transform.up * this.forwardspeed);
        }
        if (turnDirection != 0.0f)
        {
            rigidbody.AddTorque(turnDirection * this.turnspeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Astroid")
        {
            ParticleSystem ps = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
            ps.Play();
            audioSource.PlayOneShot(hit, volume);
            Ren.material.color = Color.clear;
            lose = true;
        }
    }

}
