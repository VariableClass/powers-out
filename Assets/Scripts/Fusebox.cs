﻿using UnityEngine;

public class Fusebox : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private GlobalGameData globalGameData;

    public Sprite FuseboxNoFuses;
    public Sprite FuseboxOneFuse;
    public Sprite FuseboxTwoFuses;
    public Sprite FuseboxThreeFuses;
    public Sprite FuseboxFourFuses;

    // Start is called before the first frame update
    void Start()
    {
        // Get global game data
        var globalGameDataGameObject = GameObject.FindGameObjectWithTag("GlobalData");
        globalGameData = globalGameDataGameObject.GetComponent<GlobalGameData>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Sprite candidateSprite;
        if (globalGameData.bulbsInstalled == 1)
        {
            candidateSprite = FuseboxOneFuse;
        }
        else if (globalGameData.bulbsInstalled == 2)
        {
            candidateSprite = FuseboxTwoFuses;
        }
        else if (globalGameData.bulbsInstalled == 3)
        {
            candidateSprite = FuseboxThreeFuses;
        }
        else if (globalGameData.bulbsInstalled == 4)
        {
            candidateSprite = FuseboxFourFuses;
        }
        else
        {
            candidateSprite = FuseboxNoFuses;
        }

        if (spriteRenderer.sprite != candidateSprite)
        {
            spriteRenderer.sprite = candidateSprite;
        }
    }
}