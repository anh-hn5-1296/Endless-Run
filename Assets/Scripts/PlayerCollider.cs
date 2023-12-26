using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Text locationText;
    public AudioClip collectSound;      //xu ly am thanh khi va cham
    private bool isHitStone = true;          //trang thai va cham voi da

    //Ham xu ly va cham
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")   //neu nhan vat va cham voi coin
        {
            //Xu ly am thanh
            hit.gameObject.GetComponent<Coin>().Dead(); //truy cap ham Dead từ Coin
            //tang 1 diem
            GetComponent<ScoreManager>().TangDiem(1);
        }
        if (hit.gameObject.tag == "Stone")  //neu nhan vat va cham voi da
        {
            if (isHitStone)
            {
                //Dieu chinh suc khoe nhan vat
                GetComponent<PlayerHealth>().ModifyHealth(-10);
                //tru diem
                StartCoroutine(EnabledCollider(hit, 1));    //Thread t = new Thread
            }
        }
        //Update len text cua phan canvas
        if (hit.gameObject.tag == "MushroomLocation")
        {
            locationText.text = "Mushroom: Location";
        }
        if (hit.gameObject.tag == "Stone")
        {
            locationText.text = "Stone: Location";
        }
        if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "House: Location";
        }
        if (hit.gameObject.tag == "FireLocation")
        {
            locationText.text = "Fire: Location";
        }
        if (hit.gameObject.tag == "Coin")
        {
            locationText.text = "Coin: Location";
        }
    }
    private IEnumerator EnabledCollider(ControllerColliderHit hit, float second)
    {
        isHitStone = false;
        yield return new WaitForSeconds(second);    //t.sleep(1)
        isHitStone = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
