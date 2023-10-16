using UnityEngine;

public class CubeMerge : MonoBehaviour
{
    public bool IsActive;
    public GameManager gameManager { get => _gameManager; set => _gameManager = value; }

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private CubesCofig _cubesCofig;
    [SerializeField] private Cube _myCube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (cube.Number == _myCube.Number)
            {
                if (cube.cubeMerge.IsActive) return;

                IsActive = true;
                var newCubeVelocity = _myCube.rigidbody.velocity + cube.rigidbody.velocity;
                DeactivateMergedCubes(cube);

                var newCube = Instantiate(_cubesCofig.GetNextCube(_myCube.CubeIndex));
                newCube.cubeMerge.gameManager = gameManager;
                newCube.transform.position = Vector3.Lerp(cube.transform.position, this.transform.position, Vector3.Distance(cube.transform.position, this.transform.position));
                newCube.rigidbody.velocity = newCubeVelocity / 4;
                var x = Random.Range(-2.9f, 2.9f);
                var y = Random.Range(-2.9f, 2.9f);
                var z = Random.Range(-2.9f, 2.9f);
                var jumpForce = Random.Range(200, 400);
                newCube.rigidbody.angularVelocity = new Vector3(x, y, z);
                newCube.rigidbody.AddForce(Vector3.up * jumpForce);

                gameManager.AddScore(_myCube.Number * 2);

                Destroy(cube.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    private void DeactivateMergedCubes(Cube cube)
    {
        _myCube.rigidbody.isKinematic = true;
        _myCube.collider.enabled = false;
        _myCube.meshRenderer.enabled = false;

        cube.rigidbody.isKinematic = true;
        cube.collider.enabled = false;
        cube.meshRenderer.enabled = false;
    }
}
