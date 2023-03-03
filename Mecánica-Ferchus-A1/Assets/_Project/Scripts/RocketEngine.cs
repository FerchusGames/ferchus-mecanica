using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEngine : MonoBehaviour
{
    private PhysicsEngine _physicsEngine;

    [SerializeField] private Vector3 _propulsionUnitVector;
    [SerializeField, Range(0, 1)] private float _propulsionPercentage;
    [SerializeField] private float _maxPropulsion;
    [SerializeField] private float _fuelMass;
    [SerializeField] private float _maxVelocity = 4462f; // m/s

    private Vector3 _currentPropulsion;

    private void Start()
    {
        _physicsEngine = GetComponent<PhysicsEngine>();
    }

    private void FixedUpdate()
    {
        _propulsionUnitVector = _propulsionUnitVector.normalized;
        _physicsEngine.UpdateTotalMass(_fuelMass);        
    }

    private float GetMassFlowRate()
    {
        return 0;
    }

}
