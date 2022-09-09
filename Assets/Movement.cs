using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _root;
    [SerializeField] float _walkSpeed;

    public bool IsWalking => _appliedVector.magnitude > 0.1f;
    public float WalkDistance => _appliedVector.magnitude;

    Vector2 _directionAsked;
    Vector2 _appliedVector;

    void Update()
    {
        _directionAsked.Normalize();
        _appliedVector = _directionAsked * Time.fixedDeltaTime * _walkSpeed;
        _root.MovePosition(_root.position + _appliedVector);
    }

    public void SetDirection(Vector2 vector2)
    {
        _directionAsked = vector2;
    }

    #region Editor
#if UNITY_EDITOR
    void Reset()
    {
        _root = GetComponentInParent<Rigidbody2D>();
        _walkSpeed = 5;
    }
#endif
    #endregion

}
