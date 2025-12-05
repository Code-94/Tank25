using System;
using System.Collections;
using UnityEngine;

public class TurretMod : MonoBehaviour
{

    [SerializeField] private float _detectionrange;
    
    [SerializeField] private Transform _barrel;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _lerpCompensation;
    [SerializeField] private ParticleSystem _flash;
    [SerializeField] private float _fireTime;
    [SerializeField] private float _waitTime;
    private bool _doShoot;
    private bool _playerDetected = false;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_player)
        {
            _player = GameObject.FindGameObjectWithTag("Tank").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            Vector3 playerDirection = _player.position - _barrel.position;

            if (playerDirection.magnitude < _detectionrange)
            {
                
                
                if (_playerDetected == false)
                {
                    _barrel.rotation = Quaternion.Lerp(_barrel.rotation, Quaternion.LookRotation(playerDirection),  Time.deltaTime);
                    //DoShooting();
                }
                Debug.DrawRay(_barrel.position, _barrel.forward * 100, Color.red);
            }
            
            
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_barrel.position, _detectionrange);
    }

    public void DoShooting()
    {
        Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
        _flash.Play();
    }

    
}
