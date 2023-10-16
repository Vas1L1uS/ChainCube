using System.Collections;
using UnityEngine;

public class CubeShooter : MonoBehaviour
{
    public Cube CurrentCube;

    [SerializeField] private float _forceShoot;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private LooseZone _looseZone;

    private float _distanceToCamra;
    private Vector3 _previousTouchPosition;
    private bool _isFirstTouch = true;
    private float _borderPosX = 2;
    private bool _isActive = true;

    private void Start()
    {
        CurrentCube = _spawner.SpawnCube(0);
        _distanceToCamra = Vector3.Distance(Camera.main.transform.position, this.transform.position);
    }

    private void Update()
    {
        if (_isActive == false) return;

        if (Input.touchCount > 0)
        {
            var touchPos = Input.touches[0].position;
            var ScreenToWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, _distanceToCamra));

            if (_isFirstTouch)
            {
                _previousTouchPosition = ScreenToWorldPos;
                _isFirstTouch = false;
            }

            if(CheckBorder(ScreenToWorldPos.x - _previousTouchPosition.x))
            {
                CurrentCube.transform.Translate(_previousTouchPosition.x - ScreenToWorldPos.x, 0, 0);
            }

            _previousTouchPosition = ScreenToWorldPos;
        }
        else
        {
            if (_isFirstTouch == false)
            {
                CurrentCube.rigidbody.AddForce(Vector3.forward * _forceShoot);
                StartCoroutine(TimerToSpawn());
                _isFirstTouch = true;
            }
        }
    }

    private bool CheckBorder(float translateX)
    {
        if (translateX > 0)
        {
            if (CurrentCube.transform.position.x + translateX < _borderPosX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (CurrentCube.transform.position.x + translateX > -_borderPosX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private IEnumerator TimerToSpawn()
    {
        _isActive = false;
        yield return new WaitForSeconds(1);
        _looseZone.CheckCubesInLooseZone();
        CurrentCube = _spawner.SpawnCube(Random.Range(0, 3));

        _isActive = true;
    }
}