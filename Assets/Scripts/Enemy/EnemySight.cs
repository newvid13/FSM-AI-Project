using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float sightFrequency;
    public float sightRadius;
    public Transform seenPlayer;

    private void Awake()
    {
        InvokeRepeating(nameof(Eyesight), sightFrequency, sightFrequency);
    }

    private void Eyesight()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sightRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                seenPlayer = hitCollider.transform;
                return;
            }
        }

        seenPlayer = null;
    }
}
