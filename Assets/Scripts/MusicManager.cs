using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public float masterVolume = 0.5f;
    private AudioSource audioSource;

    private void Awake()
    {
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
            SetVolume(masterVolume);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetVolume(float value)
    {
        masterVolume = value;
        AudioListener.volume = masterVolume;
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
        {
            return;
        }

        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetSong(AudioClip audioClip)
    {
        StopMusic();
        audioSource.clip = audioClip;
    }
}