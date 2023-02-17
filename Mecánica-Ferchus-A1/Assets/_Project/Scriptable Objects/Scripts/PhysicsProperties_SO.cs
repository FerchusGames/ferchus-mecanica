using UnityEngine;

[CreateAssetMenu(fileName = "PhysicsPropertiesSO", menuName = "ScriptableObjects/PhysicsPropertiesSO", order = 1)]

public class PhysicsProperties_SO : ScriptableObject
{
    [field:SerializeField] public Vector3 Velocity { get; private set; }
    [field:SerializeField] public Vector3 Torque { get; private set; }
}
