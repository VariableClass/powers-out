using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class GlobalGameData : MonoBehaviour
{
    public Vector3 playerPos;
    public int snakeHighScore;
    public bool keyGotten;
    public bool radioFixed;
    public bool powerFixed;
    public int bulbsCollected;
    public int bulbsInstalled;

    [Range(0, 50)]
    public int masterVolume;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        print("init global data");
        bulbsCollected = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetVolume(int value)
    {
        AudioListener.volume = (float)value;
    }
}

