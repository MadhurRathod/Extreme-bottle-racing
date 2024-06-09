using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public WheelJoint2D wheelFront, wheelBack;

    private JointMotor2D backMotor, frontMotor;

    public float speedForward;
    public float speedBackward;

    float speedIncreaseAmount = 600;
    float powerUpDuration = 3;

    public float torque;
    void Start()
    {
        
    }

    
    void Update()
    {
        Moves();
    }

    void Moves()
    {
        float X = Input.GetAxis("Horizontal");

        if(X > 0) 
        {
            backMotor.motorSpeed = speedForward;
            frontMotor.motorSpeed = speedForward;

            backMotor.maxMotorTorque = torque;
            frontMotor.maxMotorTorque = torque;

            wheelFront.motor = frontMotor;
            wheelBack.motor = backMotor;
        }
        else if(X < 0)
        {
            backMotor.motorSpeed = speedBackward;
            frontMotor.motorSpeed = speedBackward;

            backMotor.maxMotorTorque = torque;
            frontMotor.maxMotorTorque = torque;

            wheelFront.motor = frontMotor;
            wheelBack.motor = backMotor;
        }
        else
        {
            backMotor.motorSpeed = 0;
            frontMotor.motorSpeed = 0;

            backMotor.maxMotorTorque = torque;
            frontMotor.maxMotorTorque = torque;

            wheelFront.motor = frontMotor;
            wheelBack.motor = backMotor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bottle")
        {
            Destroy(collision.gameObject);
            Debug.Log("10 points");
        }

        else if(collision.gameObject.tag == "energy")
        {
            Destroy(collision.gameObject);
            StartCoroutine(PowerupSequence());
        }
    }

    IEnumerator PowerupSequence()
    {
        ActivatePowerup();
        yield return new WaitForSeconds(powerUpDuration);
        DeactivatePowerup();
    }

    void ActivatePowerup()
    {
        speedForward += speedIncreaseAmount;
    }

    void DeactivatePowerup()
    {
        speedForward -= speedIncreaseAmount;
    }
}
