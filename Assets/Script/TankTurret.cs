using UnityEngine;
using UnityEngine.InputSystem;

public class TankTurret : MonoBehaviour
{
    [SerializeField] private float _TurretSpeed;


    private Transform _Turret;
    private float _rotateInput;
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (_rotateInput * _TurretSpeed * Time.deltaTime));
    }

    public void TurretRot(InputAction.CallbackContext ctx)
    {
        Debug.Log("Turret in rotation" + ctx.ReadValue<float>());
        
    }
}
