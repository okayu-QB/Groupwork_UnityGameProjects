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
    //private Vector3 velocity;
    //�ړ�����
    private Vector3 direction;
    //�����t���O
    public bool arrived;
    //SetPosition�X�N���v�g
    [SerializeField]
    private SetPosition setPosition;
    public SetPosition setPos { get { return setPosition; } }
    //�҂�����
    public float waitTime = 5f;
    //�@�o�ߎ���
    private float elapsedTime;
    //�v���C���[��Transform
    private Transform playerTransform;
    //�p�g�J�[�̏��
    [SerializeField]
    private EnemyState state;
    [SerializeField]
    private Rigidbody rb;
    public Rigidbody Rigid { get { return rb; } }

    //�p�g�J�[�̏�ԕύX���\�b�h
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if(tempState == EnemyState.Patrol)
        {
            state = tempState;
        }
        else if(tempState == EnemyState.Chase)
        {
            arrived = false;
            playerTransform = targetObj;
            state = tempState;
        }
        else if(tempState == EnemyState.Wait)
        {
            Debug.Log("wait");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setPosition.SetDestination(new Vector3(34.74f, 0, 39.34f));
        rb.velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Patrol);
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
            }
            else if(state == EnemyState.Patrol && arrived == true)
            {
                //setPosition.RandomSetWayPoint();
                arrived = false;
            }
            direction = (setPosition.GetDestination() - transform.position).normalized;
            transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
            rb.velocity = direction * speed * Time.deltaTime;

            //�@�ړI�n�ɓ����������ǂ����̔���
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.1f)
            {
                Debug.Log("arrived");
                SetState(EnemyState.Wait);
                arrived = true;
            }
        }
        //�@�������Ă������莞�ԑ҂�
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //�@�҂����Ԃ��z�����玟�̖ړI�n��ݒ�
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Patrol);
                elapsedTime = 0f;
            }
        }
        //velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);
    }
    //�@�G�L�����N�^�[�̏�Ԏ擾���\�b�h
    public EnemyState GetState()
    {
        return state;
    }
}
