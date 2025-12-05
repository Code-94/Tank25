using UnityEngine;

public class ImpactSet : MonoBehaviour
{

    [SerializeField] private ParticleSystem _impact;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_impact.time > _impact.main.duration)
        {
            Destroy(gameObject);
        }
    }
}
