using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float motorForce = 500f;
    [SerializeField] private float brakeForce = 300f;
    
    [Header("References")]
    [SerializeField] private WheelCollider backLeft;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private InputActionReference leftTrigger;
    [SerializeField] private InputActionReference rightTrigger;

    private float currentMotorForce = 0f;
    private float currentBrakeForce = 0f;
    
    private void OnEnable()
    {
        leftTrigger.action.Enable();
        rightTrigger.action.Enable();
    }

    private void FixedUpdate()
    {
        // Handle acceleration and deceleration
        var isAccelerating = rightTrigger.action.ReadValue<float>() > 0f;
        var isDecelerating = leftTrigger.action.ReadValue<float>() > 0f;
        
        currentMotorForce = isAccelerating ? motorForce : 0f;
        currentBrakeForce = isDecelerating ? brakeForce : 0f;
        
        frontLeft.motorTorque = currentMotorForce;
        frontRight.motorTorque = currentMotorForce;
        
        frontLeft.brakeTorque = currentBrakeForce;
        frontRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
    }
    
    private void OnDisable()
    {
        leftTrigger.action.Disable();
        rightTrigger.action.Disable();
    }
}
