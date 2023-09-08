using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCtrl : MonoBehaviour
{
  [Header("Wheels")]
  [SerializeField] WheelCollider frontRightWheel;
  [SerializeField] WheelCollider frontLeftWheel;
  [SerializeField] WheelCollider backRightWheel;
  [SerializeField] WheelCollider backLeftWheel;

  public float acceleration = 500f;
  public float brakingForce = 300f;
  public float maxTurnAngle = 90;
  private float currentAcceleration = 0f;
  private float currentBrakeForce = 0f;
  private float currentTurnAngle = 0f;
  // Start is called before the first frame update
  void Start()
  {
    backLeftWheel.steerAngle = 90;
    backRightWheel.steerAngle = 90;
  }

  private void FixedUpdate()
  {
    //float tempV2Forward = Input.GetAxis("Vertical");

    currentAcceleration = acceleration * 1;

    frontLeftWheel.motorTorque = currentAcceleration;
    frontRightWheel.motorTorque = currentAcceleration;

    frontLeftWheel.brakeTorque = currentBrakeForce;
    backLeftWheel.brakeTorque = currentBrakeForce;
    frontRightWheel.brakeTorque = currentBrakeForce;
    backRightWheel.brakeTorque = currentBrakeForce;

    currentTurnAngle = maxTurnAngle;
    frontLeftWheel.steerAngle = currentTurnAngle;
    frontRightWheel.steerAngle = currentTurnAngle;
  }

  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("Log");
    if (other.gameObject.CompareTag("ChangeRot"))
    {
      maxTurnAngle = 90 - float.Parse(other.gameObject.name);
    }
  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetKey(KeyCode.Space))
    {
      currentBrakeForce = brakingForce;
    }
    else
    {
      currentBrakeForce = 0;
    }

  }
}
