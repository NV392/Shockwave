using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour {
    public Slider volumeSlider;
    public Slider sfxSlider;

    void Start() {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        sfxSlider.onValueChanged.AddListener(SetSFX);
    }

    void SetVolume(float value) {
    if (AudioManager.Instance != null)
        AudioManager.Instance.SetMasterVolume(value);
    }

    void SetSFX(float value) {
    if (AudioManager.Instance != null)
        AudioManager.Instance.SetSFXVolume(value);
    }
}
