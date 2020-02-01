using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameData : MonoBehaviour
{
    public bool keyGotten;
    public Vector3 playerPos;
    public int snakeHighScore;
    public bool radioFixed;
    public bool powerFixed;
    public int bulbsCollected;
    public int bulbsInstalled;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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
}

