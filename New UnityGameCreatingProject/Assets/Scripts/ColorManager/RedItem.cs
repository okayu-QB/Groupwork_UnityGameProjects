using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : AbstructColorObject
{
    public GameObject colorObject;
    ColorManager colorManager;


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();//カラーマネージャークラスのインスタンス化
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            colorManager.redCount++;//カラーマネージャー内の変数を更新

            Destroy(this.gameObject);
        }
    }
}
