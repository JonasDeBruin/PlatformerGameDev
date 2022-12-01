using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    public Vector2 worldPosition;

    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
