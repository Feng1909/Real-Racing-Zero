using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {
    public WheelCollider flWheelCollider;
    public WheelCollider frWheelCollider;
    public WheelCollider rlWheelCollider;
    public WheelCollider rrWheelCollider;

    public Transform flWheelModel;//车轮旋转
    public Transform frWheelModel;
    public Transform rlWheelModel;
    public Transform rrWheelModel;

    public Transform flDiscBrake;//车轮转向
    public Transform frDiscBrake;

    public float brakeTorque = 10000;//刹车的力量
    public int[] speedArray;
    private bool isBreaking = false;
    private float currentSpeed;
    public float motorTorque = 140;//马力
    public float steerAngle = 10;//转向
    public float maxSpeed = 250;
    public float minSpeed = 30;
    public AudioSource daiji;
    public AudioSource jiasu;
    public bool flag = false;
    public bool isBreak;
    public bool isBack;
    void Update()
    {
     
        currentSpeed = flWheelCollider.rpm * (flWheelCollider.radius * 2 * Mathf.PI) * 60 / 1000;
        /*if ((currentSpeed > maxSpeed && Input.GetAxis("Vertical") > 0) || (currentSpeed < -minSpeed && Input.GetAxis("Vertical") < 0))
        {
            flWheelCollider.motorTorque = 0;
            frWheelCollider.motorTorque = 0;
        }
        else
        {

            flWheelCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
            frWheelCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        }

     


        flWheelCollider.steerAngle = Input.GetAxis("Horizontal") * steerAngle;
        frWheelCollider.steerAngle = Input.GetAxis("Horizontal") * steerAngle;
        */

        float x = Input.acceleration.x;
        float y = Input.acceleration.y ;
        y += (float)0.75;
        if (Input.touchCount == 1)
        {
            isBreak = true;
            isBack = false;
        }
        else if(Input.touchCount ==2)
        {
            isBack = true;
            isBreak = false;
        }
        else
        {
            isBreak = false;
            isBack = false;
        }
        flWheelCollider.steerAngle = x*24;
        frWheelCollider.steerAngle = x*24;
        RotateWheel();// 转动车轮 
        SteerWheel();
        EngineSound();

        if (isBreak)//刹车
        {
            flWheelCollider.motorTorque = 0;
            frWheelCollider.motorTorque = 0;
            rlWheelCollider.motorTorque = 0;
            rrWheelCollider.motorTorque = 0;

            flWheelCollider.brakeTorque = brakeTorque;
            frWheelCollider.brakeTorque = brakeTorque;
            rlWheelCollider.brakeTorque = brakeTorque;
            rrWheelCollider.brakeTorque = brakeTorque;
        }
        else if(isBack)
        {
            flWheelCollider.motorTorque = -1 * motorTorque;
            frWheelCollider.motorTorque = -1 * motorTorque;
            rlWheelCollider.motorTorque = -1 * motorTorque;
            rrWheelCollider.motorTorque = -1 * motorTorque;

            flWheelCollider.brakeTorque = 0;
            frWheelCollider.brakeTorque = 0;
            rlWheelCollider.brakeTorque = 0;
            rrWheelCollider.brakeTorque = 0;
        }
        else
        {
            flWheelCollider.motorTorque = motorTorque / 2;
            frWheelCollider.motorTorque = motorTorque / 2;
            rlWheelCollider.motorTorque = motorTorque / 2;
            rrWheelCollider.motorTorque = motorTorque / 2;

            flWheelCollider.brakeTorque = 0;
            frWheelCollider.brakeTorque = 0;
            rlWheelCollider.brakeTorque = 0;
            rrWheelCollider.brakeTorque = 0;

        }
        RotateWheel();// 转动车轮 
        SteerWheel();//车轮转向
        EngineSound();
    }
    void RotateWheel()//车轮旋转
    {
        flDiscBrake.Rotate(flWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);
        frDiscBrake.Rotate(frWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);

        rlWheelModel.Rotate(rlWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);
        rrWheelModel.Rotate(rrWheelCollider.rpm * 6 * Time.deltaTime * Vector3.right);

    }
    void EngineSound()
    {
        
        if (!flag)
        {
            jiasu.Play();
            flag = true;
        }



    }
    void SteerWheel()
    {//控制轮子的转向

        Vector3 localEulerAngles = flWheelModel.localEulerAngles;
        localEulerAngles.y = flWheelCollider.steerAngle;

        flWheelModel.localEulerAngles = localEulerAngles;
        frWheelModel.localEulerAngles = localEulerAngles;
    }
}

