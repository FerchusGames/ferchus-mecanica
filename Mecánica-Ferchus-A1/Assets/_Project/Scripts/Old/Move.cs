using System;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private PhysicsProperties_SO _physicsPropertiesSO;
    [SerializeField] private bool _canMove;

    [SerializeField] private List<Vector3> _forceVectorList;

    private void FixedUpdate()
    {
       transform.Translate(_physicsPropertiesSO.Velocity * (_canMove ? 1 : 0) * Time.fixedDeltaTime); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 finalForce = AddForces(_forceVectorList);

            if (finalForce != Vector3.zero)
            {
                Debug.LogError("No se puede seguir con esta traslación, pues tenemos una fuerza de: " + finalForce);
                _canMove = false;
            }

            else
            {
                Debug.Log("Todo bien");
            }
        }
    }

    private Vector3 AddForces(List<Vector3> forceVectorList)
    {
        Vector3 result = Vector3.zero;

        for (int i = 0; i < forceVectorList.Count; i++)
        {
            result += forceVectorList[i];
        }

        return result;
    }
}
