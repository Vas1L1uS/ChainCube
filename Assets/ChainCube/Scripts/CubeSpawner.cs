using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubesCofig _cubesCofig;
    [SerializeField] private GameManager _gameManager;

    public Cube SpawnCube(int index)
    {
        Cube newCube = Instantiate(_cubesCofig.Cubes[index], this.transform.position, Quaternion.Euler(0, 180, 0));
        newCube.cubeMerge.gameManager = _gameManager;
        return newCube;
    }
}