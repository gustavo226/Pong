using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startingVelocity = new Vector2(5f, 5f);
    
    public GameManager gameManager;

    public float touchSpeed = 1.1f;

    public AudioClip soundClip;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
            audioSource.clip = soundClip;
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= touchSpeed;
            audioSource.clip = soundClip;
            audioSource.Play();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallPlayer2"))
        {
            gameManager.ScorePlayer1();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallPlayer1"))
        {
            gameManager.ScorePlayer2();
            ResetBall();
        }
    }
}
