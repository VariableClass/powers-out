using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryCount : MonoBehaviour
{
    private RawImage image;
    private GlobalGameData globalGameData;

    public Texture2D BatteryCount0;
    public Texture2D BatteryCount1;
    public Texture2D BatteryCount2;
    public Texture2D BatteryCount3;
    public Texture2D BatteryCount4;

    // Start is called before the first frame update
    void Start()
    {
        var globalGameDataGameObject = GameObject.FindGameObjectWithTag("GlobalData");
        globalGameData = globalGameDataGameObject.GetComponent<GlobalGameData>();

        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (globalGameData.bulbsCollected)
        {
            case 0:
                image.texture = BatteryCount0;
                break;
            case 1:
                image.texture = BatteryCount1;
                break;
            case 2:
                image.texture = BatteryCount2;
                break;
            case 3:
                image.texture = BatteryCount3;
                break;
            case 4:
                image.texture = BatteryCount4;
                break;
            default:
                break;
        }
    }
}
