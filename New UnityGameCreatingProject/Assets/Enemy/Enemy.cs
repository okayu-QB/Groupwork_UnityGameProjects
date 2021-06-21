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

    //�p�g�J�[�̈ړ����x
    public float speed;
    //�ړI�n
    private Vector3 destination;
    //�p�g�J�[�̑���
    private Vector3 velocity;
    //�ړ�����
    private Vector3 direction;
    //�����t���O
    private bool arrived;
    //SetPosition�X�N���v�g
    private SetPosition setPosition;
    //�҂�����
    public float waitTime = 5f;
    //�@�o�ߎ���
    private float elapsedTime;
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
                setPosition.SetDestination(playerTransform.position);
                direction = (setPosition.GetDestination() - transform.position).normalized;
                transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
                velocity = direction * speed;
            }

            //�@�ړI�n�ɓ����������ǂ����̔���
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
            {
                SetState(EnemyState.Wait);
                //animator.SetFloat("Speed", 0.0f);
            }
            //�@�������Ă������莞�ԑ҂�
        }
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //�@�҂����Ԃ��z�����玟�̖ړI�n��ݒ�
            if (elapsedTime > waitTime)
            {
                //SetState(EnemyState.Walk);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);
    }
}
