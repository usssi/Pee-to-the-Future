using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float minForce = 1f;
    public float maxForce = 10f;

    public bool isBootle;

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
        if (isBootle)
        {
            FindObjectOfType<AudioManager>().PlayVar("bottle", 1f);
        }
        else
        {
            FindObjectOfType<AudioManager>().PlayVar("colision", 1f);
        }
    }   

    private void OnParticleCollision(GameObject other)
    {
        ApplyRandomForce();
    }


}
