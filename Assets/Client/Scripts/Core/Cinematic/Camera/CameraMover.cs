using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _t = 0.1f;
    [SerializeField] private Transform _target;
    private Transform _self;

    private void Awake()
    {
        _self = transform;
    }

    private void FixedUpdate()
    {
        _self.position = Vector3.Lerp(_self.position, _target.position, _t);
    }
}
