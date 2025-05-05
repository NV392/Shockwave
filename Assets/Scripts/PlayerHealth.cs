using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 5;
    public int currentHealth;

    public float invincibilityDuration = 1f;
    private bool isInvincible = false;

    void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        if (isInvincible) return;

        currentHealth -= damage;

        if (currentHealth <= 0) {
            currentHealth = maxHealth;
            UIManager.Instance.hudController.UpdateHealth(currentHealth);
            
            GameManager.Instance.GameOver();
        } else {
            UIManager.Instance.hudController.UpdateHealth(currentHealth);
            StartCoroutine(Invincibility());
        }
    }

    private IEnumerator Invincibility() {
        isInvincible = true;

        float elapsed = 0f;
        Renderer rend = GetComponent<Renderer>();

        while (elapsed < invincibilityDuration) {
            rend.enabled = !rend.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }
        rend.enabled = true;
        
        isInvincible = false;
    }
}
