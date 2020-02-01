// Example script on Gaze Aware object:
// Make object spin when looked at!

using Tobii.Gaming;
using UnityEngine;

[RequireComponent(typeof(GazeAware))]
public class TobiiTestMain : MonoBehaviour
{
    private GazeAware _gazeAware;

    void Start()
    {
        _gazeAware = GetComponent<GazeAware>();
    }

    void Update()
    {
        if (_gazeAware.HasGazeFocus)
        {
            print("Stop looking at me");
            transform.Rotate(Vector3.forward);
        }
    }
}