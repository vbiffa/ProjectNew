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
            GameObject loot = Instantiate(lootPrefs[randomIndex], lootPosition.position, Quaternion.identity);

        }
    }
    

}
