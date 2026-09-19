using UnityEngine;

public class Fracture : MonoBehaviour
{
    [Tooltip("The broken version of this asteroid.")]
    public GameObject fractured;

    public bool breakAutomatically = true;

    [Tooltip("World height of the ground surface.")]
    public float groundHeight = -5f;

    private Collider rockCollider;
    private bool hasBroken;

    private void Awake()
    {
        rockCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (!breakAutomatically || hasBroken)
            return;

        float bottom = rockCollider != null
            ? rockCollider.bounds.min.y
            : transform.position.y;

        if (bottom <= groundHeight)
            FractureObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (breakAutomatically)
            FractureObject();
    }

    public void FractureObject()
    {
        if (hasBroken || fractured == null)
            return;

        hasBroken = true;
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}