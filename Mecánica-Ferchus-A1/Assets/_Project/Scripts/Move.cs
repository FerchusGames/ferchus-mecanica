using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private PhysicsProperties_SO _physicsPropertiesSO;
    [SerializeField] private bool _canMove;

    private void FixedUpdate()
    {
       transform.Translate(_physicsPropertiesSO.Velocity * (_canMove ? 1 : 0) * Time.fixedDeltaTime); 
    }
}
