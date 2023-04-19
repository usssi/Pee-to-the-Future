using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void ApplyRandomForce()
    {
        Vector3 forceDirection = Random.onUnitSphere;
        float forceMagnitude = Random.Range(minForce, maxForce);
        rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
    }

    private void OnParticleCollision(GameObject other)
    {
        ApplyRandomForce();
    }
}
