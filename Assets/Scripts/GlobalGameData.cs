using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameData : MonoBehaviour
{
    public bool keyGotten;
    public Vector3 playerPos;
    public int snakeHighScore;
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
