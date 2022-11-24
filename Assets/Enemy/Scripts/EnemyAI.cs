using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 10;
    float dirX = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

        Debug.DrawRay(transform.position, transform.right * dirX * 0.6f, Color.red, 0.1f);

        if (hit.collider != null && hit.collider.CompareTag("Ground"))
        {
            dirX *= -1f;
        }
    }
}
