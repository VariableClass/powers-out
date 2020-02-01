using System;
using UnityEngine;

public class FuseScrew : MonoBehaviour
{
    #region Properties

    public float ScrewSpeed = 3f;
    public Camera Camera;
    public Sprite FuseOff;
    public Sprite FuseOn;

    #endregion

    #region Member Variables

    private SpriteRenderer spriteRenderer;
    private float degreesRotation;
    private bool screwedIn;

    #endregion

    #region Methods

    private void Update()
    {
        if (Input.GetMouseButton(0) && !screwedIn)
        {
            gameObject.transform.Rotate(Vector3.forward * -ScrewSpeed);
            degreesRotation += Math.Abs(gameObject.transform.localRotation.eulerAngles.z);

            print(degreesRotation + " / 50000");

            if (degreesRotation > 50000)
            {
                screwedIn = true;
            }

            if (screwedIn)
            {
                spriteRenderer.sprite = FuseOn;
                var rigidBody = gameObject.GetComponent<Rigidbody2D>();
                rigidBody.freezeRotation = screwedIn;
            }
        }
    }

    private void Awake()
    {
        // Get game object components
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private Vector3 GetHeading(Vector3 mousePosition, Vector3 bulbPosition)
    {
        var x = mousePosition.x - bulbPosition.x;
        var y = mousePosition.y - bulbPosition.y;

        return new Vector3(x, y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    #endregion
}
