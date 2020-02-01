using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    private GlobalGameData globalGameData;

    private void Awake()
    {
        var globalDataObject = GameObject.FindGameObjectWithTag("GlobalData");
        globalGameData = globalDataObject.GetComponent<GlobalGameData>();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetVolume(Slider slider) => globalGameData.SetVolume((int)slider.value);
}