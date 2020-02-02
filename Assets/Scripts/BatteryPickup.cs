using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public GameObject interactText;
    public bool canInteract;
    public GlobalGameData globalData;
    public GameObject player;
    public int batteryId;

    private void Awake()
    {
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    void Start()
    {
        canInteract = false;
        if (globalData.batteryCount.IndexOf(batteryId) != -1)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKey(KeyCode.E))
        {
            globalData.batteryCount.Add(batteryId);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
            interactText.SetActive(false);
        }
    }
}
