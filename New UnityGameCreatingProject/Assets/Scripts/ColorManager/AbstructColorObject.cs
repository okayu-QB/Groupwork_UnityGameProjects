using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstructColorObject : MonoBehaviour
{

    [SerializeField]
    float rotateSpeed = 1f;
   // [SerializeField]
    float rotateAngle = 3f;

    private void LateUpdate() {
        Quaternion rotate = Quaternion.Euler(0, 0, 1 * rotateSpeed);

        Quaternion quaternion = this.transform.rotation;

        this.transform.rotation = quaternion * rotate;
    }

    void OnTriggerEnter(Collider other) {
    }
}
