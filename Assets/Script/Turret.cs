using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField] private float _detectionRange;
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _dps;

    [SerializeField] private Transform _barrel;
    [SerializeField] private float _lerpCompensation;

    
    private Transform _playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_player)
        {
            _player = GameObject.FindGameObjectWithTag("Tank");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = _playerPosition.position - _barrel.position;

        if (_playerPosition != null && _playerPosition.magnitude < _detectionRange)
        {
            
        }
        
        Quaternion wishedRotation = Quaternion.LookRotation(distance);
        _barrel.rotation = wishedRotation;

        _barrel.rotation = Quaternion.Lerp(_barrel.rotation,Quaternion.LookRotation(Vector3.forward), _lerpCompensation * Time.deltaTime);
            
    }

    private void DoLaserShooting()
    {
        if (Physics.Raycast(_barrel.position, _barrel.forward, out RaycastHit hit, Mathf.Infinity, _layers)) ;
        
        if 
    }

    private IEnumerator ShootSequence_co()
    {
        do
        {
            DoLaserShooting();
            yield return new WaitForSeconds(_fireRate);
        } while (true);
        
    }
}
