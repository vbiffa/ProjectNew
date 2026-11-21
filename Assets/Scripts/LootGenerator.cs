using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] lootPrefs;

    public void GenerateLoot(Transform[] lootPos)
    {
        foreach(Transform lootPosition in lootPos)
        {
            int randomIndex = Random.Range(0,lootPrefs.Length);
            int randomIndex2 = Random.Range(0, 4);
            if (randomIndex2 == 1)
            {
                GameObject loot = Instantiate(lootPrefs[randomIndex], lootPosition.position, Quaternion.identity);
                Vector3 eulerAngles = loot.transform.eulerAngles;
                eulerAngles.x = -90f; 
                loot.transform.eulerAngles = eulerAngles;
            }                
        }
    }
    

}
