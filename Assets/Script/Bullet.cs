using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _bulletForce;

    [SerializeField] private GameObject _Impact;
    
    private Rigidbody _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb)
        {
            _rb.AddRelativeForce(Vector3.forward * _bulletForce, ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OncollisionEnter(Collision collision)
    {
        Debug.Log("The bullet in collision with :" + collision.gameObject.name);
    }

    private void OnTouch(GameObject touch)
    {
        if (touch.TryGetComponent(out BoxDestroy box))
        {
            box.SetBulletPosition(transform.position);
        }
        
        Destroy(gameObject);
    }
    
    
    
    
}
