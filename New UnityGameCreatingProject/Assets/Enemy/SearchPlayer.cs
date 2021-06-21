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
        //プレイヤーを発見
        if(other.tag == "Player")
        {
            //パトカーの状態を取得
            Enemy.EnemyState state = Enemy.GetState();
            //パトカーがチェイス状態でなければ、チェイス状態に変更
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
