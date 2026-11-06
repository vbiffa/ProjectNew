using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    LootGenerator lootGenerator;
    [SerializeField] GameObject[] rooms;
    int roomSize = 10;
    Transform[] AllLootPos;
    
    void Start()
    {
        Vector3 currentPos = new Vector3(0,0,0);
        Vector3 move = new Vector3(roomSize,0,roomSize);
        lootGenerator = GetComponent<LootGenerator>();
        for(int i=0; i<3; i++)
        {
            int randomIndex = Random.Range(0,rooms.Length);
            GameObject loot = Instantiate(rooms[randomIndex], currentPos, Quaternion.identity);
            currentPos += move;
            AllLootPos = loot.GetComponent<RoomData>().LootXYZ;
            lootGenerator.GenerateLoot(AllLootPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
