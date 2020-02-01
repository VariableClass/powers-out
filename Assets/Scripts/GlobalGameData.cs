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
}

