using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private MeshCollider meshCollider;      //mat luoi cua coin

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();    //anh xa
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 1);     //coin xoay sang ben phai
    }
    public void Dead()
    {
        Destroy(gameObject);    //Huy coin
    }
}
