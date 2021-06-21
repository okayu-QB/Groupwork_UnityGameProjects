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
    private Vector3 velocity;
    //移動方向
    private Vector3 direction;
    //到着フラグ
    private bool arrived;
    //SetPositionスクリプト
    private SetPosition setPosition;
    //待ち時間
    public float waitTime = 5f;
    //　経過時間
    private float elapsedTime;
    //プレイヤーのTransform
    private Transform playerTransform;
    //パトカーの状態
    private EnemyState state;

    //パトカーの状態変更メソッド
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
        //巡回or追跡状態の判定
        if(state == EnemyState.Patrol || state == EnemyState.Chase)
        {
            if(state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
                direction = (setPosition.GetDestination() - transform.position).normalized;
                transform.LookAt(new Vector3(setPosition.GetDestination().x, transform.position.y, setPosition.GetDestination().z));
                velocity = direction * speed;
            }

            //　目的地に到着したかどうかの判定
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
            {
                SetState(EnemyState.Wait);
                //animator.SetFloat("Speed", 0.0f);
            }
            //　到着していたら一定時間待つ
        }
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;

            //　待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                //SetState(EnemyState.Walk);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);
    }
}
