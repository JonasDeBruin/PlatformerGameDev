using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //Conponents
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //MOVEMENT
    public float speed = 10;
    float dirX;

    //Jumping
    float jump;
    float jumpTime = 0.5f;
    [SerializeField] private int jumpForce = 10;
    [SerializeField] private float maxJumpTime = 0.5f;
    private bool isGrounded;


    public int score;
    [SerializeField] private Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
        Jumping();
    }

    private void FixedUpdate()
    {
        DirectionalMovement();
    }

    void DirectionalMovement()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.Translate(dirX * speed * Time.deltaTime * transform.right);
    }


    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce(200 * jumpForce * Vector2.up);
        }
        
        jump = Input.GetAxis("Jump");

        if (jump == 1 && !isGrounded)
        {
            jumpTime -= Time.deltaTime;
        
            Debug.Log(jumpTime);
        
            if (jumpTime > 0)
            {
                rb2d.AddForce(1.4f * 800 * Time.deltaTime * transform.up, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
            jumpTime = maxJumpTime;
        }
        if (collision.gameObject.CompareTag("RespawnKill") || collision.gameObject.layer == 8)
        {
            Death();
        }
    }

    void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb2d.AddForce(200 * 100 * Vector2.up);
    }

    private void Death()
    {
       SceneManager.LoadScene("Death");
    }
    public void AddScore()
    {
        score++;
    }
}