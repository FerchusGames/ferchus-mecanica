using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [field:SerializeField] public Vector3 Velocity { get; private set; }

    [SerializeField] private float _mass;
    [SerializeField] private bool _renderNetForce;

    private List<Vector3> _forceVectorList;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        GetForces();
        Accelerate();
        RenderVector();
    }

    private Vector3 AddForces(List<Vector3> forceVectorList)
    {
        Vector3 result = Vector3.zero;

        if(forceVectorList != null)
        {
            foreach (Vector3 force in forceVectorList)
            {
                result += force;
            }
        }

        return result;
    }

    private void GetForces()
    {
        List<Vector3> forceVectorList = new List<Vector3>();

        AddForce[] addForceList = GetComponents<AddForce>();

        if(addForceList != null)
        {
            foreach (AddForce addForce in addForceList)
            {
                forceVectorList.Add(addForce.Force);
            }
        }

        _forceVectorList = forceVectorList;
    }

    private void Accelerate()
    {
        Vector3 netForce = AddForces(_forceVectorList);
        Vector3 acceleration = netForce / _mass;
        Velocity += acceleration * Time.fixedDeltaTime;

        transform.Translate(Velocity * Time.fixedDeltaTime);

        Debug.Log("Acceleration: " + acceleration);
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
}
