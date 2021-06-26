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
	private float DestinationX;
	private float DestinationZ;

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
	public void RandomSetWayPoint()
	{
		elements = WayPointObj.WayPointList.Count;
		//�����_����0�`3�̊Ԃ̐��������
		int index = Random.Range(0, elements);
		DestinationX = WayPointObj.WayPointList[index].position.x;
		DestinationZ = WayPointObj.WayPointList[index].position.z;
		//���ݒn�Ɏ��̖ړI�n��ݒ�
		SetDestination(startPosition + new Vector3(DestinationX, 0, DestinationZ));
    }

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
