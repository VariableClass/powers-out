using System;
using UnityEngine;

public class FuseScrew : MonoBehaviour
{
    #region Properties

    public float ScrewSpeed = 3f;
    public Camera Camera;
    public Sprite FuseOff;
    public Sprite FuseOn;
    public int BulbId;

    #endregion

    #region Member Variables

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private GlobalGameData globalGameData;
    private float degreesRotation;
    private bool screwedIn;

    #endregion

    #region Methods

    private void Awake()
    {
        // Get game object components
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        // Get global game data
        var globalGameDataGameObject = GameObject.FindGameObjectWithTag("GlobalData");
        globalGameData = globalGameDataGameObject.GetComponent<GlobalGameData>();

        if (globalGameData.bulbsCollected.Count < BulbId)
        {
            Destroy(gameObject);
            return;
        }

        if (globalGameData.bulbsInstalled >= BulbId)
        {
            ScrewInFuse(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !screwedIn)
        {
            gameObject.transform.Rotate(Vector3.forward * -ScrewSpeed);
            degreesRotation += Math.Abs(gameObject.transform.localRotation.eulerAngles.z);

            print(degreesRotation + " / 50000");

            if (degreesRotation > 50000)
            {
                ScrewInFuse();
            }
        }
    }

    private void ScrewInFuse(bool newBulb = true)
    {
        screwedIn = true;
        spriteRenderer.sprite = FuseOn;
        rigidBody.freezeRotation = true;

        if (newBulb)
        {
            globalGameData.bulbsInstalled++;
        }
    }

    #endregion
}
