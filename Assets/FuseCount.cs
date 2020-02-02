using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuseCount : MonoBehaviour
{
    private RawImage image;
    private GlobalGameData globalGameData;

    public Texture2D FuseCount0;
    public Texture2D FuseCount1;
    public Texture2D FuseCount2;
    public Texture2D FuseCount3;
    public Texture2D FuseCount4;

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
        switch (globalGameData.bulbsCollected.Count)
        {
            case 0:
                image.texture = FuseCount0;
                break;
            case 1:
                image.texture = FuseCount1;
                break;
            case 2:
                image.texture = FuseCount2;
                break;
            case 3:
                image.texture = FuseCount3;
                break;
            case 4:
                image.texture = FuseCount4;
                break;
            default:
                break;
        }
    }
}
