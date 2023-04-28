using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class Spin : MonoBehaviour
{ 
    private Rigidbody _rigidbody = null;
        
    [SerializeField] private Vector3 angularVelocity = Vector3.zero;
        
    private void Awake()
    { 
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.angularVelocity = angularVelocity;
    }
}

