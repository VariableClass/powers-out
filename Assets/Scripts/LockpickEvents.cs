using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockpickEvents : MonoBehaviour
{
    public GlobalGameData globalData;

    public void Awake()
    {
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    public void Exit()
    {
        if(globalData.keyGotten)
        {
            SceneManager.LoadScene("MainGameScene");
        }
    }
}
