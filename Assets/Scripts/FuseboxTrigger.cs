using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuseboxTrigger : MonoBehaviour
{
    public GameObject interactText;
    public bool canInteract;
    public GlobalGameData globalData;
    public GameObject player;
    
    void Start()
    {
        canInteract = false;
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    private void Update()
    {
        if (canInteract && Input.GetKey(KeyCode.E))
        {
            globalData.playerPos = player.transform.position;
            SceneManager.LoadScene("Fusebox-fix");
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
