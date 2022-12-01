using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private int firePower;
    
    void Start()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("ben");
        rb2d.AddForce(worldPosition.normalized * firePower);
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
