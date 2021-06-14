using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    private Enemy Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        //�v���C���[�𔭌�
        if(other.tag == "Player")
        {
            //�p�g�J�[�̏�Ԃ��擾
            Enemy.EnemyState state = Enemy.GetState();
            //�p�g�J�[���`�F�C�X��ԂłȂ���΁A�`�F�C�X��ԂɕύX
            if(state != Enemy.EnemyState.Chase)
            {
                Debug.Log("Find Enemy");
                Enemy.SetState(Enemy.EnemyState.Chase, other.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
