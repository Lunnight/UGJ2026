using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private Rigidbody[] ragdollRigidbodies;
    private Animator animator;

    public Collider mainCapsuleCollider; 
    public Rigidbody mainRigidbody;

    void Awake()
    {
        animator = GetComponent<Animator>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    public void TriggerRagdoll()
    {
        animator.enabled = false;

        if (mainCapsuleCollider != null) mainCapsuleCollider.enabled = false;
        if (mainRigidbody != null) mainRigidbody.isKinematic = true;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
    }
}