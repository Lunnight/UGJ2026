using System.Collections.Generic;
using UnityEngine;

public class PhysicsAnimator : MonoBehaviour
{
    private Transform[] _bones;
    private Dictionary<Transform, ConfigurableJoint> _configurableJoints = new Dictionary<Transform, ConfigurableJoint>();
    private Dictionary<Transform, Quaternion> _initialRotations = new Dictionary<Transform, Quaternion>();
    private Dictionary<Transform, Quaternion> _preAnimationRotations = new Dictionary<Transform, Quaternion>();
    private Dictionary<Transform, Vector3> _preAnimationPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> _animatedRotations = new Dictionary<Transform, Quaternion>();

    void Start()
    {
        _bones = transform.GetComponentsInChildren<Transform>();

        for (var i = 0; i < _bones.Length; i++)
        {
            if (_bones[i].TryGetComponent(out ConfigurableJoint configurableJoint))
            {
                _configurableJoints[_bones[i]] = configurableJoint;
            }
                _initialRotations[_bones[i]] = _bones[i].localRotation;
        }
    }

    void Update()
    {
        //stores physics rotations without animation
        for (var i = 0; i < _bones.Length; i++)
        {
            _preAnimationRotations[_bones[i]] = _bones[i].localRotation;
            _preAnimationPositions[_bones[i]] = _bones[i].localPosition;
        }
    }

    private void LateUpdate()
    {
        //stores animated rotation without physics
        for (var i = 0; i < _bones.Length; i++)
        {
            _animatedRotations[_bones[i]] = _bones[i].localRotation;
        }

        //reverts rotations and positions to physics rotation and positions without animation
        for (var i = 0; i < _bones.Length; i++)
        {
            _bones[i].localRotation = _preAnimationRotations[_bones[i]];
            _bones[i].position = _preAnimationPositions[_bones[i]];
        }

        //apply animation to character joints
        foreach (Transform bone in _configurableJoints.Keys)
        {
            _configurableJoints[bone].SetTargetRotationLocal(_animatedRotations[bone], startLocalRotation: _initialRotations[bone]);
        }
    }
}
