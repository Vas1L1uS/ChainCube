using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseZone : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private string _cubeTag;
    [SerializeField] private Vector3 _boxSize;
    [SerializeField] private LayerMask _cubeLayerMask;

    private Vector3 _halfBoxSize;

    private void Awake()
    {
        _halfBoxSize = new Vector3(_boxSize.x / 2, _boxSize.y / 2, 0.01f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0 , 0.2f);
        Gizmos.DrawCube(this.transform.position, _boxSize);
    }

    public void CheckCubesInLooseZone()
    {
        if (Physics.BoxCast(this.transform.position, _halfBoxSize, Vector3.forward, Quaternion.identity, _boxSize.z / 2, _cubeLayerMask))
        {
            _gameManager.GameOver();
        }
    }
}
