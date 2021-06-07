using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihecle : MonoBehaviour
{
    public GameObject VihecleGameObject;
    public Rigidbody rb; //�O��ړ��p
    public float speed; //vihecle�̑��x
    public Transform VihecleTransform; //�Ǌp����p
    public float VihecleTurn; //�ʏ�̑Ǌp
    public float DriftAngle; //�h���t�g���Ǌp
    public float throttle; //���x�m�F�p
    public float MaxThrottle; //�ō���
    public float MinThrottle; //�Œᑬ
    public float Acceleration; //����
    public float Deceleration; //����
    public float MaxBoost; //�u�[�X�g�����x
    public VihecleHit FrontHitObj; //�����蔻��m�F�p�I�u�W�F�N�g

    public float BoostTank; //�u�[�X�g�c��

    public bool BoostReady;
    public bool BoostMode;
    public bool DriftMode;

    /// <summary>
    /// �������s���֐�
    /// </summary>
    private void Accel()
    {
        if (throttle < MaxThrottle)
        {
            throttle += Acceleration * Time.deltaTime;
        }
    }
    private void BoostCheck()
    {
        if (BoostTank > 0)
        {
            BoostReady = true;
        }
        else BoostReady = false;
    }
    private void Boost()
    {
        BoostMode = true;
        if (throttle < MaxBoost)
        {
            throttle += Acceleration * 2.5f * Time.deltaTime;
        }
        BoostTank -= 50f * Time.deltaTime;
    }
    private void BoostOff()
    {
        BoostMode = false;
        if(throttle > MaxThrottle)
        {
            Decel();
        }
    }
    public void BoostSupply(float BoostAmount)
    {
        BoostTank += BoostAmount;
    }

    /// <summary>
    /// �������s���֐�
    /// </summary>
    private void Decel()
    {
        if (throttle > MinThrottle)
        {
            throttle -= Deceleration * Time.deltaTime;
        }
    }
    private void HitVihecle()
    {
        throttle = 0;
        FrontHitObj.FrontHit = false;
    }

    /// <summary>
    /// Vihecle�̃X�s�[�h���Ǘ�����֐�
    /// </summary>
    private void VihecleSpeed()
    {
        speed = rb.velocity.magnitude;
        if(speed < 100f)
        {
            rb.velocity = VihecleTransform.forward * throttle * Time.deltaTime;
        }
    }

    /// <summary>
    /// Vihecle�����E�Ƀ^�[�������邽�߂̊֐�
    /// </summary>
    private void LeftTurn()
    {
        VihecleTransform.Rotate(0, -VihecleTurn, 0);
    }
    private void RightTurn()
    {
        VihecleTransform.Rotate(0, VihecleTurn, 0);
    }

    /// <summary>
    /// Vihecle���}���Ƀ^�[�������邽�߂̊֐�
    /// </summary>
    private void LeftDrift()
    {
        DriftMode = true;
        VihecleTransform.Rotate(0, -DriftAngle, 0);
    }
    private void RightDrift()
    {
        DriftMode = true;
        VihecleTransform.Rotate(0, DriftAngle, 0);
    }

    private void DriftOff()
    {
        DriftMode = false;
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
        BoostCheck();
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && BoostReady == true)
        {
            Boost();
        }
        else
        {
            BoostOff();
        }
        if (Input.GetKey(KeyCode.W) && BoostMode == false)
        {
            Accel();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Decel();
        }

        if (FrontHitObj.FrontHit == true)
        {
            HitVihecle();
        }
        VihecleSpeed();

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
        {
            LeftDrift();
        }
        else
        {
            DriftOff();
        }
        if (Input.GetKey(KeyCode.A) && DriftMode == false)
        {
            LeftTurn();
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
        {
            RightDrift();
        }
        else
        {
            DriftOff();
        }
        if (Input.GetKey(KeyCode.D) && DriftMode == false)
        {
            RightTurn();
        }
    }
}
