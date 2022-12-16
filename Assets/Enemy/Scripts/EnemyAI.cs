using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class EnemyAI : MonoBehaviour
{
    //Components
    private BoxCollider2D colliderEnemy;
    private Renderer spriteRender;
    private Animator deathAnim;
    [SerializeField] private GameObject deathSound;
    [SerializeField] private PlayerMovement player;

    //Variables
    [SerializeField] private float speed = 10;
    [SerializeField] private Color deathColor;
    float dirX = 1;
    private bool dead = false;


    //Position
    public float Xpos;
    public float Ypos;

    private void Start()
    {
        //Getting components
        deathAnim = GetComponent<Animator>();
        colliderEnemy = GetComponent<BoxCollider2D>();
        spriteRender = GetComponent<Renderer>();

        Xpos = transform.position.x;
        Ypos = transform.position.x;

        if (Random.Range(1, 3) == 1)
        {
            dirX = -1;        
        }
        else
        {
            dirX = 1;
        }

    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            transform.Translate(dirX * speed * Time.deltaTime * transform.right);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

            Debug.DrawRay(transform.position, 0.6f * dirX * transform.right, Color.red, 0.1f);

            if (hit.collider != null && hit.collider.CompareTag("Ground") || (hit.collider != null && hit.collider.CompareTag("Enemy")))
            {
                dirX *= -1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Death events
        if (collision.gameObject.layer == 7)
        {
            colliderEnemy.enabled = false;
            spriteRender.material.color = deathColor;
            Instantiate(deathSound);
            deathAnim.SetBool("OnDeath", true);

            dead = true;
            player.AddScore();
            Destroy(gameObject, 1);
        }

        if (collision.gameObject.CompareTag("RespawnKill"))
        {
            transform.position = new Vector2(Random.Range(-28, 24), 40);
        }
    }
}
