using UnityEngine;

public class EnemyPawn : Pawn {
    public Transform target;

    public override void HandleMovement() {
        if (target == null) return;
        Vector3 dir = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + dir * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        print(collision);
        if (collision.gameObject.CompareTag("Player")) {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null) {
                player.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
