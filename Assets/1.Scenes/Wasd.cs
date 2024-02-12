using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasd : MonoBehaviour


{
    void Start()
    {
        Debug.Log("Hello");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0.0f, 0.0001f, 0.0f);
        }
    }
}
