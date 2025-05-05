using UnityEngine;

public abstract class Pawn : MonoBehaviour {
    public float moveSpeed = 0.5f;
    protected Rigidbody rb;

    protected virtual void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void HandleMovement();
}
