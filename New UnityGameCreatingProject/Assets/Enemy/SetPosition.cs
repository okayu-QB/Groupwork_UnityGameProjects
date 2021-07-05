using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{

	//初期位置
	private Vector3 startPosition;
	//目的地
	[SerializeField]
	private Vector3 destination;
	//WayPointListの要素数
	private int elements;
	//目的地の座標
	public float DestinationX;
	public float DestinationY;
	public float DestinationZ;
	//WayPointManagerのゲームオブジェクト
	public WayPointManager WayPointManagerObj;

	[SerializeField]
	private GameObject NearrestWayPoint;

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

	//Enemyから一番近いWayPointを目的地に設定
	public void SetNearestWayPoint()
    {
	    float tmpDis = 0;
		float nearDis = 0;
		GameObject cmpObj;

		for(int i = 0;i < WayPointManagerObj.childrencount; i++)
        {
			cmpObj = WayPointManagerObj.AllWayPointList[i];
			tmpDis = Vector3.Distance(transform.position, cmpObj.transform.position);

			if(nearDis == 0 || nearDis > tmpDis)
            {
				nearDis = tmpDis;
				NearrestWayPoint = cmpObj;
				Debug.Log("NearestPoint is " + NearrestWayPoint);
            }
        }

		SetDestination(NearrestWayPoint.transform.position);
    }

	//目的地のWayPointをランダムに設定
	public void RandomSetWayPoint(List<Transform> list)
	{
		elements = list.Count;
		//ランダムに0～3の間の整数を取る
		int index = (int)(Time.realtimeSinceStartup % list.Count);
		//Debug.Log("SetRange:" + index);
		DestinationX = list[index].position.x;
		DestinationY = list[index].position.y;
		DestinationZ = list[index].position.z;
		//現在地に次の目的地を設定
		//Debug.Log("x:" + DestinationX + " z:" + DestinationZ);
		SetDestination(new Vector3(DestinationX, DestinationY, DestinationZ));
    }

    //目的地を変更する
    //public void ChangeDestination(WayPoint wayPoint)
    //{
    //    WayPointObj = wayPoint;
    //}

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
