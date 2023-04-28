using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts
{
    public class GravitationalForce : MonoBehaviour
    {
        private const float GravitationalConstant = .0000000000667f;

        [SerializeField] private bool isInKilometers;
    
        public List<PhysicsEngine> _physicsEngineList;

        private void FixedUpdate()
        {
            AddGravitationForce();
        }

        private void AddGravitationForce()
        {
            foreach (var physicsEngine1 in _physicsEngineList)
            {
                foreach (var physicsEngine2 in _physicsEngineList)
                {
                    if (physicsEngine1 == physicsEngine2) continue;
                    
                    var distance = Vector3.Distance(physicsEngine1.transform.position, physicsEngine2.transform.position);
                    if (isInKilometers) distance *= 1000;
                    
                    var magnitude = GravitationalConstant * ((physicsEngine1.TotalMass * physicsEngine2.TotalMass) / Mathf.Pow(distance, 2));
                    var direction = (physicsEngine2.transform.position - physicsEngine1.transform.position).normalized;
                    var force = magnitude * direction;

                    physicsEngine1.AddForce(force);
                }
            }
        }
    }
}