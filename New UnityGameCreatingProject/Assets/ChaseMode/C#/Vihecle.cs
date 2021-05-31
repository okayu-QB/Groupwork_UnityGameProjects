using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihecle : MonoBehaviour
{
    public GameObject VihecleGameObject;
    public Rigidbody rb; //前後移動用
    public float speed; //vihecleの速度
    public Transform VihecleTransform; //舵角操作用
    public float VihecleTurn; //通常の舵角
    public float DriftAngle; //ドリフト時舵角
    public float throttle; //速度確認用
    public float MaxThrottle; //最高速
    public float MinThrottle; //最低速
    public float Acceleration; //加速
    public float Deceleration; //減速
    public float MaxBoost; //ブースト時速度
    public VihecleHit FrontHitObj; //当たり判定確認用オブジェクト

    public float BoostTank; //ブースト残量

    public bool BoostReady;
    public bool BoostMode;
    public bool DriftMode;

    /// <summary>
    /// 加速を行う関数
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
    /// 減速を行う関数
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
    /// Vihecleのスピードを管理する関数
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
    /// Vihecleを左右にターンさせるための関数
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
    /// Vihecleを急速にターンさせるための関数
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
