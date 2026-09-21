using UnityEngine;

public class FacilityCollapse : MonoBehaviour
{
    public float impactForce = 5f;
    private bool hasCollapsed;

    public void Collapse(Vector3 impactPoint)
    {
        if (hasCollapsed)
            return;

        hasCollapsed = true;

        foreach (Rigidbody piece in GetComponentsInChildren<Rigidbody>())
        {
            piece.isKinematic = false;
            piece.useGravity = true;

            piece.AddExplosionForce(
                impactForce,
                impactPoint,
                0f,
                1f,
                ForceMode.Impulse
            );
        }
    }
}