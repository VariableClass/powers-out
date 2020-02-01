using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameData : MonoBehaviour
{
    public bool keyGotten;
    public Vector3 playerPos;
    public int snakeHighScore;
    public bool radioFixed;
    public bool powerFixed;

    [Range(0, 50)]
    public int masterVolume;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        keyGotten = false;
        snakeHighScore = 0;
        radioFixed = false;
        powerFixed = false;

        print("init global data");
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

