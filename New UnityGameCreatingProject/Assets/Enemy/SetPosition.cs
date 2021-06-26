using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{

	//初期位置
	private Vector3 startPosition;
	//目的地
	private Vector3 destination;
	//WayPointのリスト
	public WayPoint WayPointObj;
	//WayPointListの要素数
	private int elements;
	//目的地の座標
	private float DestinationX;
	private float DestinationZ;

	// Start is called before the first frame update
	void Start()
    {
		//　初期位置を設定(コレのせいで巡回がおかしくなる可能性アリ)
		startPosition = transform.position;
		SetDestination(transform.position);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	//目的地のWayPointをランダムに設定
	public void RandomSetWayPoint()
	{
		elements = WayPointObj.WayPointList.Count;
		//ランダムに0～3の間の整数を取る
		int index = Random.Range(0, elements);
		DestinationX = WayPointObj.WayPointList[index].position.x;
		DestinationZ = WayPointObj.WayPointList[index].position.z;
		//現在地に次の目的地を設定
		SetDestination(startPosition + new Vector3(DestinationX, 0, DestinationZ));
    }

    //　目的地を設定する
    public void SetDestination(Vector3 position)
	{
		destination = position;
	}

	//　目的地を取得する
	public Vector3 GetDestination()
	{
		return destination;
	}
}
