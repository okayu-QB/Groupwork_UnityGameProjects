using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{

	//�����ʒu
	private Vector3 startPosition;
	//�ړI�n
	private Vector3 destination;
	//WayPoint�̃��X�g
	public WayPoint WayPointObj;
	//WayPointList�̗v�f��
	private int elements;
	//�ړI�n�̍��W
	public float DestinationX;
	public float DestinationZ;

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

	//�ړI�n��WayPoint�������_���ɐݒ�
	public void RandomSetWayPoint(List<Transform> list)
	{
		elements = list.Count;
		//�����_����0�`3�̊Ԃ̐��������
		int index = (int)(Time.realtimeSinceStartup % list.Count);
		Debug.Log("SetRange:" + index);
		DestinationX = list[index].position.x;
		DestinationZ = list[index].position.z;
		//���ݒn�Ɏ��̖ړI�n��ݒ�
		Debug.Log("x:" + DestinationX + " z:" + DestinationZ);
		SetDestination(new Vector3(DestinationX, 0, DestinationZ));
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
