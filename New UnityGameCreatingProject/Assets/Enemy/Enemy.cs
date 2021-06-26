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

    //パトカーの移動速度
    public float speed;
    //目的地
    private Vector3 destination;
    //パトカーの速さ
    //private Vector3 velocity;
    //移動方向
    private Vector3 direction;
    //到着フラグ
    public bool arrived;
    //SetPositionスクリプト
    [SerializeField]
    private SetPosition setPosition;
    public SetPosition setPos { get { return setPosition; } }
    //待ち時間
    public float waitTime = 5f;
    //　経過時間
    private float elapsedTime;
    //プレイヤーのTransform
    private Transform playerTransform;
    //パトカーの状態
    [SerializeField]
    private EnemyState state;
    [SerializeField]
    private Rigidbody rb;
    public Rigidbody Rigid { get { return rb; } }

    //パトカーの状態変更メソッド
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
        //巡回or追跡状態の判定
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

            //　目的地に到着したかどうかの判定
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.1f)
            {
                Debug.Log("arrived");
                SetState(EnemyState.Wait);
                arrived = true;
            }
        }
        //　到着していたら一定時間待つ
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //　待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Patrol);
                elapsedTime = 0f;
            }
        }
        //velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);
    }
    //　敵キャラクターの状態取得メソッド
    public EnemyState GetState()
    {
        return state;
    }
}
