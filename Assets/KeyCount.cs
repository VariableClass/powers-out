using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCount : MonoBehaviour
{
    private RawImage image;
    private GlobalGameData globalGameData;

    public Texture2D KeyCount0;
    public Texture2D KeyCount1;


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
        switch (globalGameData.keyGotten)
        {
            case true:
                image.texture = KeyCount0;
                break;
            case false:
                image.texture = KeyCount1;
                break;

            default:
                break;
        }
    }
}
