using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;   // mang dia hinh
    private Transform player;           // nhan vat
    private List<GameObject> activeTiles; //cac dia hinh dang active
    private float spawnZ = 0f;           // khoang cach bien doi
    private float tileLength = 44f;     //chieu dai dia hinh
    private int tilesOnScreen = 4;      //so dia hinh hien thi dong thoi tren man hinh

    //ham tao dia hinh sau khi nhan vat di het
    private void TaoDiaHinh(int index = 1)
    {
        GameObject gameObject;          //khai bao
        if (index == 0)                 // chỉ so =0 -> thanh phan dau tien cua mang
        {
            gameObject = Instantiate(tilesPrefabs[0]);  //dua dia hinh so 0 vao
        }
        else        //Lay ngau nhien 1 dia hinh o trong mang
        {
            gameObject= Instantiate(tilesPrefabs[Random.Range(1, tilesPrefabs.Length)]);
        }
        //Dua dinh hinh moi tao vao game
        gameObject.transform.SetParent(transform);
        //Thuc hien bien doi dia hinh
        gameObject.transform.position = Vector3.forward * spawnZ;
        //Xac dinh vi tri moi
        spawnZ += tileLength;
        //Dua dia hinh vao mang 
        activeTiles.Add(gameObject);
    }
    //Ham xoa dia hinh
    private void XoaDiaHinh()
    {
        Destroy(activeTiles[0]);    //Huy
        activeTiles.RemoveAt(0);    //Xoa trong mang
    }

    // Start is called before the first frame update
    void Start()
    {
        //Khoi tao cac bien, mang, anh xa cac nhan vat
        activeTiles = new List<GameObject>();   //khoi tao danh sach dia hinh
        player = GameObject.FindGameObjectWithTag("Player").transform;  //anh xa
        //Su dung vong lap de khoi tao dia hinh
        for (int i = 0; i < tilesOnScreen; i++) 
        { 
            if (i <1)
            {
                TaoDiaHinh(0);
            }    
            else
            {
                TaoDiaHinh();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Tao dia hinh khi nhan vat den va xoa nhan vat khi nhan vat di qua
        //dieu kien tao dia hinh
        if((player.position.z - tileLength) > (spawnZ - tileLength * tilesOnScreen))
        {
            TaoDiaHinh();       //Tao khi nhan vat den
            XoaDiaHinh();       //Xoa khi nhan vat di
        }
    }
}
