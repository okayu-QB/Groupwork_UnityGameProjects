using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    float horizontalKey = Input.GetAxisRaw("Horizontal");
    bool jumpKey = Input.GetButton("Jump");
    Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
}
