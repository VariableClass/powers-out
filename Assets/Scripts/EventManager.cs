using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    private MusicManager musicManager;

    private void Awake()
    {
        musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetVolume(Slider slider) => musicManager.SetVolume(slider.value);
}