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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.tag);
        //プレイヤーを発見
        if (other.tag == "Player")
        {
            //パトカーの状態を取得
            Enemy.EnemyState state = moveenemy.GetState();
            //パトカーがチェイス状態でなければ、チェイス状態に変更
            if (state != Enemy.EnemyState.Chase)
            {
                moveenemy.SetState(Enemy.EnemyState.Chase, other.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("見失う");
            moveenemy.LostEnemy = true;
            moveenemy.SetState(Enemy.EnemyState.Patrol);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
