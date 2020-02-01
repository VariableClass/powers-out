using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST : MonoBehaviour
{
    public GameObject globalData;

    private void Awake()
    {
        globalData = GameObject.FindGameObjectWithTag("GlobalData");
    }

    // Start is called before the first frame update
    void Start()
    {
        globalData.GetComponent<GlobalGameData>().powerFixed = true;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
