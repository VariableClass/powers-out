using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_button : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
