using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueItem : AbstructColorObject
{
    public GameObject colorObject;
    ColorManager colorManager;


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            colorManager.blueCount++;

            Destroy(this.gameObject);
        }
    }
}
