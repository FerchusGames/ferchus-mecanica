using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PrintPhysicsInfo : MonoBehaviour
{
    private  Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(this.name + " = " + _rigidbody.inertiaTensor);
    }
}
