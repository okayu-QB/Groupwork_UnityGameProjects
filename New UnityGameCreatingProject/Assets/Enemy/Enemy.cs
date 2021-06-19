using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Wait,
        Chase
    };

    //�ړI�n
    private Vector3 destination;
    //�p�g�J�[�̑���
    private Vector3 velocity;
    //�ړ�����
    private Vector3 direction;
    //�����t���O
    private bool arrived;
    //�҂�����
    public float waitTime = 5f;
    //�v���C���[��Transform
    private Transform playerTransform;
    //�p�g�J�[�̏��
    private EnemyState state;

    //�p�g�J�[�̏�ԕύX���\�b�h
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if(tempState == EnemyState.Patrol)
        {
            state = tempState;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //����or�ǐՏ�Ԃ̔���
        if(state == EnemyState.Patrol || state == EnemyState.Chase)
        {
            if(state == EnemyState.Chase)
            {

            }
        }
    }
}
