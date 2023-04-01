using UnityEngine;

namespace _Project.Scripts
{
    [RequireComponent(typeof(PhysicsEngine))]
    public class RocketEngine : MonoBehaviour
    {
        const float EffectiveVelocity = 4462f; // [M/s]

        [SerializeField] private Vector3 propulsionUnitVector;

        [SerializeField, Range(0, 1)] private float propulsionPercentage;
        [SerializeField] private float maxPropulsion; //[KN  m/s^2]
        [SerializeField] private float fuelMass; //[Kg]

        private PhysicsEngine _physicsEngine;

        private float _currentPropulsion;

        private void Start()
        {
            _physicsEngine = GetComponent<PhysicsEngine>();
            _physicsEngine.AddToTotalMass(fuelMass);
        }

        private void FixedUpdate()
        {
            if (fuelMass > 0)
            {
                fuelMass -= MassFlow() * Time.fixedDeltaTime;
                _physicsEngine.AddToTotalMass(-MassFlow() * Time.fixedDeltaTime);
                _currentPropulsion = propulsionPercentage * maxPropulsion * 1000f;
                Vector3 propulsionVector = propulsionUnitVector.normalized * _currentPropulsion; //[N]
                _physicsEngine.AddForce(propulsionVector);
            }
            else Debug.LogWarning("No Fuel Left");

            propulsionUnitVector = propulsionUnitVector.normalized;
            _physicsEngine.UpdateTotalMass(fuelMass);        
        }

        private float MassFlow()
        {
            return _currentPropulsion / EffectiveVelocity;
        }

    }
}