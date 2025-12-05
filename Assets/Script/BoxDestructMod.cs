using UnityEngine;

public class BoxDestructMod : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem _Boum;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            _Boum.Play();
        }
    }
}
