using UnityEngine;

namespace _Project.Scripts
{
    public class FluidDrag : MonoBehaviour
    {
        [Range(1, 2), SerializeField] private float dragExponent = 1;
        [SerializeField] private float dragCoefficient;
        private PhysicsEngine _physicsEngine;
        
        private void Awake()
        {
            _physicsEngine = GetComponent<PhysicsEngine>();
        }

        private void FixedUpdate()
        {
            float speed = _physicsEngine.Velocity.magnitude;
            float dragMagnitude = dragCoefficient * Mathf.Pow(speed, dragExponent);
            Vector3 dragForce = dragMagnitude * -_physicsEngine.Velocity.normalized;
            _physicsEngine.AddForce(dragForce);
        }
    }
}
