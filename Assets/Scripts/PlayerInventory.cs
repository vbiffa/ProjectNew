using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Transform rightHand;
    bool autoCollect = false;
    GameObject holding;
    GameObject holdingCurrently;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(holdingCurrently != null)
        {
            holdingCurrently.transform.position = rightHand.position;
            if(Input.GetKeyDown(KeyCode.G))
            {
                DropItem();
            }
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            autoCollect = !autoCollect;
        }
        
    }
    void PickInRH(GameObject item)
    {
        holdingCurrently = Instantiate(item, rightHand.position, Quaternion.identity);
        holdingCurrently.GetComponent<BoxCollider>().enabled = false;
        holdingCurrently.GetComponent<Rigidbody>().useGravity = false;
    }
    void EnableDropped(GameObject dropped)
    {
        dropped.GetComponent<BoxCollider>().enabled = true;
        dropped.GetComponent<Rigidbody>().useGravity = true;
    }
    void DropItem()
    {
        GameObject dropping = Instantiate(holdingCurrently, rightHand.position - new Vector3(0, 0.75f, 0), Quaternion.identity);;
        dropping.GetComponent<BoxCollider>().enabled = false;
        dropping.GetComponent<Rigidbody>().useGravity = false;
        Destroy(holdingCurrently);
        EnableDropped(dropping);
    }
    void  OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Loot")
        {
            if (autoCollect && holdingCurrently == null) 
                {
                    holding = other.gameObject;
                    Destroy(other.gameObject);
                    PickInRH(holding);
                }
        }
    }
}
