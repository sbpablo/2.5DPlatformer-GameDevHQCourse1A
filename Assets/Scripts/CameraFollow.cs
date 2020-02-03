using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    private Vector3 _offset;
    void Start()
    {
        _offset = transform.position - _target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.transform.position + _offset;
    }
}
