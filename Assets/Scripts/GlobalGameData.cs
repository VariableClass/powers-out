using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameData : MonoBehaviour
{
    public Vector3 playerPos;
    public int snakeHighScore;
    public bool keyGotten;
    public bool radioFixed;
    public bool powerFixed;
    public List<int> bulbsCollected;
    public int bulbsInstalled;
    public List<int> batteryCount;

    [Range(0, 50)]
    public int masterVolume;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        print("init global data");
        bulbsCollected = new List<int>();
        batteryCount = new List<int>();
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

