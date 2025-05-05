using UnityEngine;

public class PlayerController : MonoBehaviour {
    public PlayerPawn pawn;

    void Update() {
        pawn?.HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space)) {
            pawn?.UseShockwave();
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            pawn.moveSpeed = 10f;
        } else {
            pawn.moveSpeed = 5f;
        }
    }
}
