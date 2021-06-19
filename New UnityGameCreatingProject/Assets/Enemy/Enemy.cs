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

    //目的地
    private Vector3 destination;
    //パトカーの速さ
    private Vector3 velocity;
    //移動方向
    private Vector3 direction;
    //到着フラグ
    private bool arrived;
    //待ち時間
    public float waitTime = 5f;
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

            }
        }
    }
}
