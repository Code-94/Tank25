using UnityEngine;

public class Bonus : MonoBehaviour
{

    [SerializeField] private int _value = 1;

    [SerializeField] private ParticleSystem _choc;
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
        if (other.collider.CompareTag("Tank"))
        {
            Destroy(gameObject);
            _choc.Play();
        }
        
    }
}
