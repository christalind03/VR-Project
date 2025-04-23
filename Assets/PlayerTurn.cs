using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PlayerTurn : MonoBehaviour
{
    [Header("Refereces")]
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private XRKnob steeringWheel;
    
    private void FixedUpdate()
    {
        frontLeft.steerAngle = steeringWheel.m_CurrentKnobRotation;
        frontRight.steerAngle = steeringWheel.m_CurrentKnobRotation;
    }
}
