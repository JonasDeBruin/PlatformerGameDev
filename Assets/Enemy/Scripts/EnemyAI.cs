using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float speed = 10;
    float dirX = 1;
    private bool dead = false;

    public float Xpos;
    public float Ypos;



    [SerializeField] private GameObject deathSound;
    [SerializeField] private PlayerMovement player;

    private void Start()
    {

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

            if (hit.collider != null && hit.collider.CompareTag("Ground"))
            {
                dirX *= -1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Death
        if (collision.gameObject.layer == 7)
        {
            dead = true;
            player.AddScore();
            Instantiate(deathSound);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("RespawnKill"))
        {
            transform.position = new Vector2(Random.Range(-28, 24), 40);
        }
    }
}
