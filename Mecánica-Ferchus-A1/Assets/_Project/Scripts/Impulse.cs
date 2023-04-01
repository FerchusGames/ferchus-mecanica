using UnityEngine;

namespace _Project.Scripts
{
    public class Impulse : MonoBehaviour
    {
        [field: SerializeField] public Vector3 Force { get; private set; }

        private PhysicsEngine _physicsEngine;

        private void Start()
        {
            _physicsEngine = GetComponent<PhysicsEngine>();
            _physicsEngine.AddForce(Force);
        }
    }
}