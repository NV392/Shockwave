using UnityEngine;

public class ChaseAI : EnemyAI {
    private void Update() {
        Tick();
    }

    public override void Tick() {
        if (pawn.target == null) {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null) pawn.target = player.transform;
        }
        pawn.HandleMovement();
    }
}
