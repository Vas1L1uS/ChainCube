using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CubesConfig", menuName = "CubesConfig")]
public class CubesCofig : ScriptableObject
{
    public List<Cube> Cubes => _cubes;

    [SerializeField] private List<Cube> _cubes = new List<Cube>();

    public Cube GetNextCube(int currentIndex)
    {
        if (currentIndex >= _cubes.Count - 1)
        {
            return _cubes[0];
        }
        else
        {
            return _cubes[currentIndex + 1];
        }
    }
}