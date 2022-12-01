using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int firePower;
    private Vector3 mousPos;
    private Camera mainCam;
    private Rigidbody2D rb;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousPos - transform.position;
        Vector3 rotation = transform.position - mousPos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * firePower;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        Destroy(gameObject, 3);
    }
}
