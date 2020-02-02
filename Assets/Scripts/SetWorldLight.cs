using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SetWorldLight : MonoBehaviour
{
    public GlobalGameData globalData;
    public GameObject worldLight;
    public GameObject flashlight;
    public GameObject characterLight;

    // Start is called before the first frame update
    void Start()
    {
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalData.powerFixed)
        {
            worldLight.GetComponent<Light2D>().intensity = 1;
            flashlight.GetComponent<Light2D>().intensity = 0;
            characterLight.GetComponent<Light2D>().intensity = 0;
        }
    }
}
