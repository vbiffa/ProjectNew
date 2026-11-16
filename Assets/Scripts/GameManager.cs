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
        int mapSize = 3;
        Vector3 currentPos = new Vector3(0,0,0);
        Vector3 moveX = new Vector3(roomSize,0,0);
        Vector3 moveZ = new Vector3(0,0,roomSize);
        lootGenerator = GetComponent<LootGenerator>();
        for(int j=0; j<mapSize; j++)
        {
            for(int i=0; i<mapSize; i++)
            {
                int randomIndex = Random.Range(0,rooms.Length);
                GameObject loot = Instantiate(rooms[randomIndex], currentPos, Quaternion.identity);
                currentPos += moveX;
                AllLootPos = loot.GetComponent<RoomData>().LootXYZ;
                lootGenerator.GenerateLoot(AllLootPos);
            }
            currentPos += moveZ;
            currentPos -= moveX * mapSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
