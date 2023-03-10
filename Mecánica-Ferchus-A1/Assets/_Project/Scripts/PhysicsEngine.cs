using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [field:SerializeField] public Vector3 Velocity { get; private set; }

    [SerializeField] private float _objectMass;
    [SerializeField] private float _totalMass;
    [SerializeField] private bool _renderNetForce;

    private List<Vector3> _forceVectorList;
    private LineRenderer _lineRenderer;
    private Vector3 _netForce;

    private void Start()
    {
        _totalMass = _objectMass;
        _forceVectorList = new List<Vector3>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        RenderVector();
        Accelerate();
        ResetForces();
    }

    public void AddForce(Vector3 force)
    {
        _forceVectorList.Add(force);
        _netForce += force;
    }

    private void ResetForces()
    {
        if (_forceVectorList !=  null)
        {
            _forceVectorList.Clear();   
        }
        _netForce = Vector3.zero;
    }

    private void Accelerate()
    {
        Vector3 acceleration = _netForce / _totalMass;
        Velocity += acceleration * Time.fixedDeltaTime;

        transform.Translate(Velocity * Time.fixedDeltaTime);

        Debug.Log("Acceleration: " + acceleration);
    }

    public void UpdateTotalMass(float addedMass)
    {
        _totalMass = _objectMass + addedMass;
    }

    private void RenderVector()
    {
        _lineRenderer.enabled = _renderNetForce;

        if(_renderNetForce && _forceVectorList != null)
        {
            int verticesCount = _forceVectorList.Count * 2;

            _lineRenderer.positionCount = verticesCount;

            _lineRenderer.startWidth = 0.1f;
            _lineRenderer.endWidth = 0.1f;
            _lineRenderer.startColor = Color.cyan;
            _lineRenderer.endColor = Color.cyan;

            Vector3[] verticesPositons = new Vector3[verticesCount]; 

            for (int i = 0; i < verticesCount; i = i + 2)
            {
                verticesPositons[i] = transform.position;
                verticesPositons[i + 1] = transform.position - _forceVectorList[i / 2];
            }

            _lineRenderer.SetPositions(verticesPositons);
        }
    }

    public void AddToTotalMass(float mass)
    {
        _totalMass += mass;
    }
}

