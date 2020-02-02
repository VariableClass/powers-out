using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFix : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GlobalGameData globalGameData;
    private MusicManager music;

    public Sprite RadioNoBattery;
    public Sprite RadioWithBattery;
    public AudioClip audioClip;
    
    void Start()
    {
        // Get global game data
        var globalGameDataGameObject = GameObject.FindGameObjectWithTag("GlobalData");
        globalGameData = globalGameDataGameObject.GetComponent<GlobalGameData>();


        var musicManagerObject = GameObject.FindGameObjectWithTag("Music");
        music = musicManagerObject.GetComponent<MusicManager>();
        
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (globalGameData.batteryCount.Count > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                sprite.sprite = RadioWithBattery;
                globalGameData.radioFixed = true;
                music.SetSong(audioClip);
            }
        }
    }
}
