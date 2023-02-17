using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private PhysicsProperties_SO _physicsProperties_SO;

    private void FixedUpdate()
    {
        transform.Rotate(_physicsProperties_SO.Torque * Time.fixedDeltaTime);
    }
}
