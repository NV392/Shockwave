using UnityEngine;

public abstract class EnemyAI : MonoBehaviour {
    protected EnemyPawn pawn;

    protected virtual void Start() {
        pawn = GetComponent<EnemyPawn>();
    }

    public abstract void Tick();
}
