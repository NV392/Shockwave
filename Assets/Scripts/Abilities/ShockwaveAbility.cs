using UnityEngine;
using System.Collections.Generic;

public class ShockwaveAbility : MonoBehaviour {
    public float cooldown = 3f;
    private float lastUsed = -Mathf.Infinity;
    public float radius = 100f;
    public float force = 20000f;

    public GameObject shockwaveParticlesPrefab;
    public AudioClip shockwaveSound;
    public Transform shockwaveSpawnPoint;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void TryUse() {
        if (Time.time - lastUsed < cooldown) return;

        Instantiate(shockwaveParticlesPrefab, shockwaveSpawnPoint.position, shockwaveSpawnPoint.rotation);
        audioSource.PlayOneShot(shockwaveSound);

        lastUsed = Time.time;
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (var hit in hits) {
            if (hit.CompareTag("Enemy")) {
                Rigidbody enemyRb = hit.GetComponent<Rigidbody>();
                if (enemyRb != null) {
                    Vector3 dir = (hit.transform.position - transform.position).normalized;
                    enemyRb.AddForce(dir * force);
                }
            }
        }
    }
}
