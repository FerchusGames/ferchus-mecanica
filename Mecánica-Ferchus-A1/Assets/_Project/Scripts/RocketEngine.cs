using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]

public class RocketEngine : MonoBehaviour
{
    const float EFFECTIVE_VELOCITY = 4462f; // [M/s]

    [SerializeField] private Vector3 _propulsionUnitVector;

    [SerializeField, Range(0, 1)] private float _propulsionPercentage;
    [SerializeField] private float _maxPropulsion; //[KN  m/s^2]
    [SerializeField] private float _fuelMass; //[Kg]

    private PhysicsEngine _physicsEngine;

    private float _currentPropulsion;

    private void Start()
    {
        _physicsEngine = GetComponent<PhysicsEngine>();
        _physicsEngine.AddToTotalMass(_fuelMass);
    }

    private void FixedUpdate()
    {
        if (_fuelMass > 0)
        {
            _fuelMass -= MassFlow() * Time.fixedDeltaTime;
            _physicsEngine.AddToTotalMass(-MassFlow() * Time.fixedDeltaTime);
            _currentPropulsion = _propulsionPercentage * _maxPropulsion * 1000f;
            Vector3 propulsionVector = _propulsionUnitVector.normalized * _currentPropulsion; //[N]
            _physicsEngine.AddForce(propulsionVector);
        }
        else Debug.LogWarning("No Fuel Left");

        _propulsionUnitVector = _propulsionUnitVector.normalized;
        _physicsEngine.UpdateTotalMass(_fuelMass);        
    }

    private float MassFlow()
    {
        return _currentPropulsion / EFFECTIVE_VELOCITY;
    }

}
