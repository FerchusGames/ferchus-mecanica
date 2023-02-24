using UnityEngine;
using UnityEngine.Animations;

public class ConstraintController : MonoBehaviour
{
    private ParentConstraint _parentConstraint;

    void Start()
    {
        _parentConstraint = GetComponent<ParentConstraint>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            _parentConstraint.constraintActive = !_parentConstraint.constraintActive;
        }
    }
}
