using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    [SerializeField]
    private Enemy moveenemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //�v���C���[�𔭌�
        if(other.tag == "Player")
        {
            //�p�g�J�[�̏�Ԃ��擾
            Enemy.EnemyState state = moveenemy.GetState();
            //�p�g�J�[���`�F�C�X��ԂłȂ���΁A�`�F�C�X��ԂɕύX
            if (state != Enemy.EnemyState.Chase)
            {
                Debug.Log("Find Enemy");
                moveenemy.SetState(Enemy.EnemyState.Chase, other.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("������");
            moveenemy.SetState(Enemy.EnemyState.Patrol);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
