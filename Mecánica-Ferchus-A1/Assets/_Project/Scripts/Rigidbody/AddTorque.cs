using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorque : MonoBehaviour
{
     [SerializeField] private Vector3 torque = Vector3.zero;    
     [SerializeField] private float timeToApplyTorque = 0f;
     
     private Rigidbody _rigidbody = null;
     private float _timePassed = 0f;
    
    private void Awake()
    {
        _timePassed = 0f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _timePassed += Time.fixedDeltaTime;

        if (_timePassed < timeToApplyTorque)
        { 
            _rigidbody.AddTorque(torque * Time.fixedDeltaTime);
        }
    }
}
