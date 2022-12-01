using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootLoc;
    [SerializeField] private BoxCollider2D playerCollision;
    [SerializeField] private CircleCollider2D bulletCollision;

    // Update is called once per frame
    void Update()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, shootLoc.position, Quaternion.identity);
            Physics2D.IgnoreCollision(bulletCollision, playerCollision);
        }
    }
}
