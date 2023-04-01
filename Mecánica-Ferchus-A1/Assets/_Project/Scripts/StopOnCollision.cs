using UnityEngine;

namespace _Project.Scripts
{
    public class StopOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter()
        {
            Debug.Log("Collided");
            GetComponent<PhysicsEngine>().enabled = false;
        }
    }
}