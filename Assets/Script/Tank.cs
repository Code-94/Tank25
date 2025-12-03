using System.Collections;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [SerializeField] private float _fwdSpeed;
    [SerializeField] private float _rotateSpeed;
    
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawn;
    
    

    private float _moveInput;
    private float _rotateInput;
    
    
    private Rigidbody _rb;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(Vector3.forward * (_moveInput * _fwdSpeed * Time.deltaTime));
        Vector3 velocity = _moveInput * _fwdSpeed * transform.forward;
        _rb.linearVelocity = new Vector3(velocity.x, _rb.linearVelocity.y, velocity.z);
        
        _rb.angularVelocity = _rotateInput * Mathf.Deg2Rad * _rotateSpeed * transform.up;
        //_rb.angularVelocity = _turretRotInput * Mathf.Deg2Rad * _turretRotSpeed * transform.right;
        
    }

    public void MoveForward(InputAction.CallbackContext ctx)
    {
        Debug.Log("Moving forward :" + ctx.ReadValue<float>());
        _moveInput = ctx.ReadValue<float>();
    }

    public void Rotation(InputAction.CallbackContext ctx)
    {
        Debug.Log("Moving in Rotation :" + ctx.ReadValue<float>());
        _rotateInput = ctx.ReadValue<float>();
    }

    public void DoShooting(InputAction.CallbackContext ctx)
    {
        Debug.Log("Fire :" + ctx.ReadValue<float>());
        if (ctx.performed)
        {
            Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
        }
        
    }

    

    
}
