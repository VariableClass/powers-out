using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFix : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GlobalGameData globalGameData;

    public Sprite RadioNoBattery;
    public Sprite RadioWithBattery;


    // Start is called before the first frame update
    void Start()
    {
        // Get global game data
        var globalGameDataGameObject = GameObject.FindGameObjectWithTag("GlobalData");
        globalGameData = globalGameDataGameObject.GetComponent<GlobalGameData>();

        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (globalGameData.batteryCount > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                sprite.sprite = RadioWithBattery;
            }
        }


        //TODO: insert battery visually
        //Good job message
        //Change music
    }
}
