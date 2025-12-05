using System;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{

    [SerializeField] private float _capForce;
    [SerializeField] private float _boxForce;
    [SerializeField] private Rigidbody _cap;
    [SerializeField] private Rigidbody _box;
    
    private Vector3 _projectilePosition;
    
    private Action<BoxDestroy> OnBoxDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBulletPosition(Vector3 position)
    {
        _projectilePosition = position;
    }
    public void Explode()
    {
        Debug.Log("BOUM !");
        _cap.AddForce(Vector3.up * _capForce);
        _box.AddForce((_projectilePosition - transform.position) * _boxForce);

        Collider myCollider = GetComponent<Collider>();
        Destroy(myCollider);
            
        OnBoxDestroy.Invoke(this);
    }
}
