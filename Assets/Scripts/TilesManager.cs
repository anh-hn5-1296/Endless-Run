using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;   // m?ng ??a hình
    private Transform player;           // nhân v?t
    private List<GameObject> activeTiles; //các ??a hình ?ang active
    private float spawnZ = 0;           // kho?ng cách bi?n ??i

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
