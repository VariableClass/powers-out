using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideHitbox : MonoBehaviour
{
    void Start()
    {
        GetComponent<TilemapRenderer>().enabled = false;
        //tilemapRenderer.enabled = false;
    }
}
