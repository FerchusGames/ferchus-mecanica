using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private PhysicsEngine _objectToFollow;
    [SerializeField] private bool _isFollowing;

    void FixedUpdate()
    {
        if(_isFollowing)
        {
            transform.Translate(_objectToFollow.Velocity * Time.fixedDeltaTime);
        }
    }
}
