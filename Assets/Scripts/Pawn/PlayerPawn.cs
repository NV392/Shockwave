using UnityEngine;

public class PlayerPawn : Pawn {
    public int currentHealth = 3;

    public ShockwaveAbility shockwave;

    public override void HandleMovement() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v).normalized;

        if (move.magnitude > 0.1f) {
            rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
            Quaternion toRot = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, 720f * Time.deltaTime);
        }
    }

    public void UseShockwave() {
        shockwave?.TryUse();
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        HUDController hud = FindObjectOfType<HUDController>();
        hud.UpdateHealth(currentHealth);
    }
}
