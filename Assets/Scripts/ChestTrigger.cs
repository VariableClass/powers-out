using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestTrigger : MonoBehaviour
{
    public GameObject interactText;
    public bool canInteract;
    public GlobalGameData globalData;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
        globalData = GameObject.FindGameObjectWithTag("GlobalData").GetComponent<GlobalGameData>();
    }

    private void Update()
    {
        if(canInteract && Input.GetKey(KeyCode.E))
        {
            globalData.playerPos = player.transform.position;
            SceneManager.LoadScene("Lockpicker");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
