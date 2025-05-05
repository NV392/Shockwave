using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public GameObject sfxSource;

    [Header("Settings")]
    [Range(0f, 1f)] public float masterVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    void Start()
    {
        UpdateVolumes();
    }

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        UpdateVolumes();
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        UpdateVolumes();
    }

    private void UpdateVolumes()
    {
        musicSource.volume = masterVolume;
        sfxSource.GetComponent<AudioSource>().volume = masterVolume * sfxVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.GetComponent<AudioSource>().PlayOneShot(clip, sfxVolume);
        }
    }
}
