using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
    public static HUDController Instance;

    public Text healthText;
    public Text waveText;

    public void UpdateHealth(int currentHealth) {
        healthText.text = "HP: " + currentHealth;
    }

    public void UpdateWave(int currentWave) {
        waveText.text = "Wave: " + currentWave;
    }
}
