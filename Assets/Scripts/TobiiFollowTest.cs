using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class TobiiFollowTest : MonoBehaviour
{
    public Vector2 lookatPoint;
    Camera camera;
    public GameObject moveObject;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        lookatPoint = new Vector2(0,0);
        camera = GetComponent<Camera>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        UserPresence userPresence = TobiiAPI.GetUserPresence();
        if (userPresence.IsUserPresent())
        {
            lookatPoint = camera.ScreenToWorldPoint(TobiiAPI.GetGazePoint().Screen);
            var moveVector = new Vector3(lookatPoint.x - moveObject.transform.position.x, lookatPoint.y - moveObject.transform.position.y, 0).normalized;
            moveObject.transform.Translate(moveVector * Time.deltaTime * speed);
        }
    }
}
