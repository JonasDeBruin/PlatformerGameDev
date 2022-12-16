using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(GameObject.FindGameObjectsWithTag("Enemy").Length);

        if (GameObject.FindGameObjectsWithTag("Opponent").Length == 0)
        {
            // Show 'Cleared' UI menu
        }
    }
}
