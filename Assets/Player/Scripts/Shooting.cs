using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;

    [SerializeField] private GameObject fireAudio;

    private Camera mainCam;
    private Vector3 mousPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousPos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetButtonDown("Fire1"))
        {
            //Create bullet
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            //Create audiooo
            Instantiate(fireAudio, transform.position, Quaternion.identity);
        }
    }
}
