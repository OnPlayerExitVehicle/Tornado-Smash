using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugControl : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
