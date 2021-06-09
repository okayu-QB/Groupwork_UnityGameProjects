using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : AbstructColorObject
{
    public GameObject colorObject;
    ColorManager colorManager;


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            colorManager.redCount++;

            Destroy(this.gameObject);
        }
    }
}
