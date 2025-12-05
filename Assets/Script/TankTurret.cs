using UnityEngine;
using UnityEngine.InputSystem;

public class TankTurret : MonoBehaviour
{

    [SerializeField] private float _TankTurretSpeed;
    
    private float _TankTurretRotInput;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.Rotate(Vector3.up * _TankTurretRotInput * _TankTurretSpeed);
    }

    public void TurretTank(InputAction.CallbackContext ctx)
    {
        Debug.Log("TurretTank in rotation" + ctx.ReadValue<float>());
        _TankTurretRotInput = ctx.ReadValue<float>();
    }
    
}
