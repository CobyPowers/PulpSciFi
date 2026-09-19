using UnityEngine;

public class Meteor_Impact : MonoBehaviour
{
    public GameObject fractured;
    public FacilityCollapse facility;

    public float burstForce = 8f;
    public float upwardLift = 2f;

    private bool hasBroken;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasBroken)
            return;

        // Collapse only when the meteor hits this facility.
        if (facility != null &&
            collision.collider.transform.IsChildOf(facility.transform))
        {
            Vector3 impactPoint = collision.contactCount > 0
                ? collision.GetContact(0).point
                : transform.position;

            facility.Collapse(impactPoint);
        }

        FractureObject();
    }

    public void FractureObject()
    {
        if (hasBroken || fractured == null)
            return;

        hasBroken = true;

        GameObject pieces = Instantiate(
            fractured,
            transform.position,
            transform.rotation
        );

        pieces.SetActive(true);

        foreach (Rigidbody piece in pieces.GetComponentsInChildren<Rigidbody>())
        {
            piece.AddExplosionForce(
                burstForce,
                transform.position,
                0f,
                upwardLift,
                ForceMode.Impulse
            );
        }

        Destroy(gameObject);
    }
}