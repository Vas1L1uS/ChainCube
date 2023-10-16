using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int CubeIndex => _cubeIndex;
    public int Number => _number;
    public CubeMerge cubeMerge => _cubeMerge;
    public new Rigidbody rigidbody { get => _rigidbody; set=> _rigidbody = value; }
    public new Collider collider { get => _collider; set => _collider = value; }
    public MeshRenderer meshRenderer { get => _meshRenderer; set => _meshRenderer = value; }

    [SerializeField] private int _cubeIndex;
    [SerializeField] private int _number;
    private CubeMerge _cubeMerge;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _cubeMerge = this.GetComponent<CubeMerge>();
        _rigidbody = this.GetComponent<Rigidbody>();
        _collider = this.GetComponent<Collider>();
        _meshRenderer = this.GetComponent<MeshRenderer>();
    }
}