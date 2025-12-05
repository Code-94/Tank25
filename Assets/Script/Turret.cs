using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField] private float _detectionRange;
    [SerializeField] private float _fireTime;
    [SerializeField] private float _waitTime;
    //[SerializeField] private float _dps;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private ParticleSystem _flash;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _barrel;
    [SerializeField] private float _lerpCompensation;

    [SerializeField] private LayerMask _layers;

    private bool _playerDetected = false;
    private bool _doShoot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!_playerPosition)
        {
            _playerPosition = GameObject.FindWithTag("Tank").transform;
        }
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_barrel.LookAt(_playerPosition);
        
        
        if(_playerPosition != null)
        {
            Vector3 playerDirection = _playerPosition.position - _barrel.position;
            if (playerDirection.magnitude < _detectionRange)
            {
                if (_playerDetected == false)
                {
                    StartCoroutine(ShootSequence_co());
                    _playerDetected = true;
                }
                _barrel.rotation = Quaternion.Lerp(_barrel.rotation,
                    Quaternion.LookRotation(playerDirection),
                    _lerpCompensation * Time.deltaTime);
            }
            else
            {
                StopAllCoroutines();
                _playerDetected = false;
                _barrel.rotation = Quaternion.Lerp(_barrel.rotation,
                    Quaternion.LookRotation(Vector3.forward),
                    _lerpCompensation * Time.deltaTime);
            }

        }
        else
        {
            StopAllCoroutines();
        }
        
        if (_doShoot) DoShooting();
        
    }

    private void DoShooting()
    {
        Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
        _flash.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_barrel.position, _detectionRange);
    }
    
    private IEnumerator ShootSequence_co()
    {
        do
        {
            _doShoot = true;
            yield return new WaitForSeconds(_fireTime);
            
            _doShoot = false;
            yield return new WaitForSeconds(_waitTime);
            
        } while (true);

    }
}
