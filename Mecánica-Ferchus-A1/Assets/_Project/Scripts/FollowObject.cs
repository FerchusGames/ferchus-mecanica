using UnityEngine;

namespace _Project.Scripts
{
    public class FollowObject : MonoBehaviour
    {
        [SerializeField] private PhysicsEngine objectToFollow;
        [SerializeField] private bool isFollowing;

        void FixedUpdate()
        {
            if(isFollowing)
            {
                transform.Translate(objectToFollow.Velocity * Time.fixedDeltaTime);
            }
        }
    }
}