using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    public GlobalGameData globalData;
    public GameObject credits;

    void Start()
    {
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalData.powerFixed)
        {
            credits.SetActive(true);
        }
    }
}
