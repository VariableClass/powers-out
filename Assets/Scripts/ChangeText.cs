using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GlobalGameData globalGameData;

    public Sprite HaveBatteries;
    public Sprite NoBatteries;

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
        if (globalGameData.batteryCount.Count > 0)
        {
            sprite.sprite = HaveBatteries;
        }
    }
}
