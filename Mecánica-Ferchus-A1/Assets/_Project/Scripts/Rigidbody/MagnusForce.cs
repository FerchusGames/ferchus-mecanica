using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusForce : MonoBehaviour
{
    [SerializeField] private float magnusCoefficient = 0f;
    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(CalculateMagnusForce() * Time.fixedDeltaTime);
    }
    
    private Vector3 CalculateMagnusForce()
    {
        return magnusCoefficient * Vector3.Cross(_rigidbody.angularVelocity, _rigidbody.velocity);
    }
}
