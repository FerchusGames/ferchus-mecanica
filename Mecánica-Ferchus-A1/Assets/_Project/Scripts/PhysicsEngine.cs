using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    [RequireComponent(typeof (LineRenderer))]

    public class PhysicsEngine : MonoBehaviour
    {
        [field:SerializeField] public Vector3 Velocity { get; private set; }

        [SerializeField] private float objectMass;
        public float TotalMass { get; private set; }
        [FormerlySerializedAs("_renderNetForce")] [SerializeField] private bool renderNetForce;

        private List<Vector3> _forceVectorList;
        private LineRenderer _lineRenderer;
        private Vector3 _netForce;
    
        private void Awake()
        {
            TotalMass = objectMass;
            _forceVectorList = new List<Vector3>();
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void FixedUpdate()
        {
            Accelerate();
            RenderVector();

            ResetForces();
        }

        public void AddForce(Vector3 force)
        {
            //Debug.Log("Added a force of: " + force);
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
            Vector3 acceleration = _netForce / TotalMass;
            Velocity += acceleration * Time.fixedDeltaTime;

            transform.Translate(Velocity * Time.fixedDeltaTime);

            //Debug.Log("Acceleration: " + acceleration);
        }

        public void UpdateTotalMass(float addedMass)
        {
            TotalMass = objectMass + addedMass;
        }

        private void RenderVector()
        {
            if (_lineRenderer != null)
            {
                _lineRenderer.enabled = renderNetForce;

                if(renderNetForce && _forceVectorList != null)
                {
                    int verticesCount = _forceVectorList.Count * 2;

                    _lineRenderer.positionCount = verticesCount;

                    _lineRenderer.startWidth = 0.1f;
                    _lineRenderer.endWidth = 0.1f;
                    _lineRenderer.startColor = Color.cyan;
                    _lineRenderer.endColor = Color.cyan;

                    Vector3[] verticesPositions = new Vector3[verticesCount];

                    for (int i = 0; i < verticesCount; i = i + 2)
                    {
                        verticesPositions[i] = transform.position;
                        verticesPositions[i + 1] = transform.position - _forceVectorList[i / 2];
                    }
                    _lineRenderer.SetPositions(verticesPositions);
                }
            }
        }

        public void AddToTotalMass(float mass)
        {
            TotalMass += mass;
        }
    }
}