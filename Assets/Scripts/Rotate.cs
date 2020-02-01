using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rotate : MonoBehaviour
{
    public bool unlocked = false;
    public int wiggleRoom = 20;
    public GameObject keyhole;
    public GameObject closedChest;
    public GameObject openChest;
    private int sweetSpot;
    private Vector3 mousePosition;
    public bool inRange;
    public bool inRange2;
    public bool inRange3;
    public bool inRange4;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        sweetSpot = GetSweetSpot();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            RotateLockClockwise();
        }
        else
        {
            if (!unlocked)
            {
                RotateLockCounterClockwise();
            }
            RotateCenter();
        }
    }

    private void RotateLockClockwise()
    {
        if (inRange)
        {
            int angle = (int)keyhole.transform.rotation.eulerAngles.z;
            if (angle <= 0 || angle >= 270)
            {
                keyhole.transform.Rotate(new Vector3(0, 0, -1 * 2));
                if (keyhole.transform.rotation.eulerAngles.z < 270)
                {
                    keyhole.transform.localEulerAngles = new Vector3(keyhole.transform.rotation.eulerAngles.x, keyhole.transform.rotation.eulerAngles.y, 270);
                }
                if (keyhole.transform.rotation.eulerAngles.z == 270)
                {
                    unlocked = true;
                    audioData.Play();
                }
            }
        }
        else if (inRange2)
        {
            int angle = (int)keyhole.transform.rotation.eulerAngles.z;
            if (angle <= 0 || angle >= 290)
            {
                keyhole.transform.Rotate(new Vector3(0, 0, -1 * 2));
                if (keyhole.transform.rotation.eulerAngles.z < 270)
                {
                    keyhole.transform.localEulerAngles = new Vector3(keyhole.transform.rotation.eulerAngles.x, keyhole.transform.rotation.eulerAngles.y, 270);

                }
            }
            else if ((angle > 0 && angle <= 290) && !unlocked)
            {
                transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (float)Math.Sin(DateTime.Now.Millisecond));
            }

        }
        else if (inRange3)
        {
            int angle = (int)keyhole.transform.rotation.eulerAngles.z;
            if (angle <= 0 || angle >= 315)
            {
                keyhole.transform.Rotate(new Vector3(0, 0, -1 * 2));
                if (keyhole.transform.rotation.eulerAngles.z < 270)
                {
                    keyhole.transform.localEulerAngles = new Vector3(keyhole.transform.rotation.eulerAngles.x, keyhole.transform.rotation.eulerAngles.y, 270);
                }
            }
            else if ((angle > 0 && angle <= 315) && !unlocked)
            {
                transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (float)Math.Sin(DateTime.Now.Millisecond));
            }

        }
        else if (inRange4)
        {
            int angle = (int)keyhole.transform.rotation.eulerAngles.z;
            if (angle <= 0 || angle >= 330)
            {
                keyhole.transform.Rotate(new Vector3(0, 0, -1 * 2));
                if (keyhole.transform.rotation.eulerAngles.z < 270)
                {
                    keyhole.transform.localEulerAngles = new Vector3(keyhole.transform.rotation.eulerAngles.x, keyhole.transform.rotation.eulerAngles.y, 270);
                }
            }
            else if ((angle > 0 && angle <= 330) && !unlocked)
            {
                transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + (float)Math.Sin(DateTime.Now.Millisecond));
            }
        }
    }

    private void RotateLockCounterClockwise()
    {
        unlocked = false;
        int angle = (int)keyhole.transform.rotation.eulerAngles.z;
        if (angle <= 359 && angle >= 269)
        {
            keyhole.transform.Rotate(new Vector3(0, 0, 1 * 2));
            if (keyhole.transform.rotation.eulerAngles.z > 0 && keyhole.transform.rotation.eulerAngles.z < 270)
            {
                keyhole.transform.localEulerAngles = new Vector3(keyhole.transform.rotation.eulerAngles.x, keyhole.transform.rotation.eulerAngles.y, 0);
            }
        }
    }

    private void RotateCenter()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.LookAt(mousePosition);
        var mouseVector = new Vector3(mousePosition.x - gameObject.transform.position.x, mousePosition.y - gameObject.transform.position.y, 0);
        transform.up = mouseVector;
        CheckIsInRange();
    }

    private void CheckIsInRange()
    {
        int centerAngle = (int)transform.rotation.eulerAngles.z;
        inRange = IsInRange(centerAngle, wiggleRoom);
        inRange2 = IsInRange(centerAngle, wiggleRoom + 25);
        inRange3 = IsInRange(centerAngle, wiggleRoom + 60);
        inRange4 = IsInRange(centerAngle, wiggleRoom + 85);
    }

    public int GetSweetSpot()
    {
        System.Random random = new System.Random();
        return random.Next(1, 360);
    }

    public bool IsInRange(int angle, int wiggleRoom)
    {
        bool inRange = false;
        int min = sweetSpot - wiggleRoom / 2;
        if (min < 0)
        {
            min = 360 - Math.Abs(min);
        }
        int max = sweetSpot + wiggleRoom / 2;
        if (max > 360)
        {
            max = Math.Abs(max) - 360;
        }
        if (min > max)
        {
            if (angle >= min || angle <= max)
            {
                inRange = true;
            }
        }
        else if (min <= angle && angle <= max)
        {
            inRange = true;
        }
        return inRange;
    }
}
