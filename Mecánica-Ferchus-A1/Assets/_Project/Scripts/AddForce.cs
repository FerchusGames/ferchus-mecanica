using UnityEngine;

public class AddForce : MonoBehaviour
{
    [field: SerializeField] public Vector3 Force { get; private set; }

    private PhysicsEngine _physicsEngine;

    private void Start()
    {
        _physicsEngine = GetComponent<PhysicsEngine>();
    }

    private void FixedUpdate()
    {
        _physicsEngine.AddForce(Force);
    }
}
