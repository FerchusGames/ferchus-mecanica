using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [field: SerializeField] public Vector3 Velocity;

    [SerializeField] private List<Vector3> _forceVectorList;
    [SerializeField] private Vector3 _velocity;

    [SerializeField] private float _mass;
    [SerializeField] private bool _renderNetForce;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        Vector3 netForce = AddForces(_forceVectorList);
        Vector3 acceleration = netForce / _mass;
        Velocity += acceleration * Time.fixedDeltaTime;

        transform.Translate(Velocity * Time.fixedDeltaTime);

        Debug.Log("Acceleration: " + acceleration);

        _lineRenderer.enabled = _renderNetForce;

        if(_renderNetForce)
        {
            RenderVector(netForce);
        }
    }

    private Vector3 AddForces(List<Vector3> forceVectorList)
    {
        Vector3 result = Vector3.zero;

        foreach (Vector3 force in forceVectorList)
        {
            result += force;
        }

        return result;
    }

    private void RenderVector(Vector3 vector)
    {
        _lineRenderer.SetPositions(new Vector3[] { transform.position, transform.position + vector });

        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.startColor = Color.cyan;
        _lineRenderer.endColor = Color.cyan;
    }
}
