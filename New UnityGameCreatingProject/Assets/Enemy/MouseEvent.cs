using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    float speed  = 0.02f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 0.04f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(0, 0, speed);
        }
        speed = 0.02f;
    }
}
