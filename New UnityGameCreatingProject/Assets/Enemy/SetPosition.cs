using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{

	//�����ʒu
	private Vector3 startPosition;
	//�ړI�n
	[SerializeField]
	private Vector3 destination;
	//WayPointList�̗v�f��
	private int elements;
	//�ړI�n�̍��W
	public float DestinationX;
	public float DestinationY;
	public float DestinationZ;
	//WayPointManager�̃Q�[���I�u�W�F�N�g
	public WayPointManager WayPointManagerObj;

	[SerializeField]
	private GameObject NearrestWayPoint;

	// Start is called before the first frame update
	void Start()
    {
		//�@�����ʒu��ݒ�(�R���̂����ŏ��񂪂��������Ȃ�\���A��)
		startPosition = transform.position;
		SetDestination(transform.position);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	//Enemy�����ԋ߂�WayPoint��ړI�n�ɐݒ�
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

	//�ړI�n��WayPoint�������_���ɐݒ�
	public void RandomSetWayPoint(List<Transform> list)
	{
		elements = list.Count;
		//�����_����0�`3�̊Ԃ̐��������
		int index = (int)(Time.realtimeSinceStartup % list.Count);
		//Debug.Log("SetRange:" + index);
		DestinationX = list[index].position.x;
		DestinationY = list[index].position.y;
		DestinationZ = list[index].position.z;
		//���ݒn�Ɏ��̖ړI�n��ݒ�
		//Debug.Log("x:" + DestinationX + " z:" + DestinationZ);
		SetDestination(new Vector3(DestinationX, DestinationY, DestinationZ));
    }

    //�ړI�n��ύX����
    //public void ChangeDestination(WayPoint wayPoint)
    //{
    //    WayPointObj = wayPoint;
    //}

    //�@�ړI�n��ݒ肷��
    public void SetDestination(Vector3 position)
	{
		destination = position;
	}

	//�@�ړI�n���擾����
	public Vector3 GetDestination()
	{
		return destination;
	}
}
