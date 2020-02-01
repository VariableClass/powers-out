﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    #region Enums
    private enum Bearing
    {
        NorthEast,
        SouthEast,
        SouthWest,
        NorthWest
    }

    #endregion

    #region Properties

    public float PlayerSpeed = 1.5f;
    public Camera Camera;
    public Sprite NorthEast;
    public Sprite NorthWest;
    public Sprite SouthEast;
    public Sprite SouthWest;

    public GameObject flashLight;
    public GameObject characterLight;
    public GlobalGameData globalData;

    #endregion

    #region Member Variables

    private SpriteRenderer spriteRenderer;

    #endregion

    #region Methods
    private void Awake()
    {
        // Get game object components
        spriteRenderer = GetComponent<SpriteRenderer>();
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    private void Start()
    {
        var temp = new Vector3(0, 0, 0);
        if(globalData.playerPos != temp)
        {
            transform.position = globalData.playerPos;
        }
    }

    private Vector2? GetHeading(Vector3 mousePosition, Vector3 characterPosition)
    {
        // If the character is at the cursor position, do not move
        if ((characterPosition.x == mousePosition.x) || (characterPosition.y == mousePosition.y))
        {
            return null;
        }

        var x = mousePosition.x - characterPosition.x;
        var y = mousePosition.y - characterPosition.y;

        return new Vector2(x, y);
    }

    private Vector2? GetIsometricHeading(Vector2 heading)
    {
        var margin = 0.05;

        if ((heading.x < margin && heading.x > -margin) || (heading.y < margin && heading.y > -margin))
        {
            return null;
        }

        var x = heading.x > 0 ? 1 : -1;
        var y = heading.y > 0 ? 1 : -1;

        // Multiply in order to get correct isometric behaviour for games
        return new Vector2(x*2, y);
    }

    private Bearing GetBearing(Vector2 heading)
    {
        if (heading.x > 0 && heading.y > 0)
        {
            // Both positive: NE
            return Bearing.NorthEast;
        }
        else if (heading.x < 0 && heading.y > 0)
        {
            // Y positive, X negative: NW
            return Bearing.NorthWest;
        }
        else if (heading.x < 0 && heading.y < 0)
        {
            // Both negative: SW
            return Bearing.SouthWest;
        }
        else
        {
            return Bearing.SouthEast;
        }
    }

    private Sprite GetSpriteForBearing(Bearing bearing)
    {
        if (bearing == Bearing.NorthEast)
        {
            return NorthEast;
        }
        else if (bearing == Bearing.NorthWest)
        {
            return NorthWest;
        }
        else if (bearing == Bearing.SouthEast)
        {
            return SouthEast;
        }
        else
        {
            return SouthWest;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // Get mouse position
            var mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);

            // Determine the character heading from the character's current position and the mouse position
            var heading = GetHeading(mousePosition, transform.position);

            // Get an isometric heading for the given heading
            var isometricHeading = GetIsometricHeading(heading.Value);

            // If the character is at the cursor position, do not move
            if (!isometricHeading.HasValue)
            {
                return;
            }

            // Get the compass bearing for the heading
            var bearing = GetBearing(heading.Value);

            // Set the appropriate character sprite for the given bearing
            spriteRenderer.sprite = GetSpriteForBearing(bearing);

            flashLight.transform.up = isometricHeading.Value;
            characterLight.transform.up = isometricHeading.Value;
            characterLight.transform.Rotate(new Vector3(0, 0, 1), 180);

            // Move the character
            transform.Translate(isometricHeading.Value * Time.fixedDeltaTime * PlayerSpeed);
        }
    }
    #endregion
}
