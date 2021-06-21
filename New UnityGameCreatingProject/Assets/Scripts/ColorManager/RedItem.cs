using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : AbstructColorObject
{
    public GameObject colorObject;
    ColorManager colorManager;


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();//�J���[�}�l�[�W���[�N���X�̃C���X�^���X��
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            colorManager.redCount++;//�J���[�}�l�[�W���[���̕ϐ����X�V

            Destroy(this.gameObject);
        }
    }
}
