using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    [SerializeField] Transform[] lootXYZ;
    public Transform[] LootXYZ {get{return lootXYZ;} private set{}}
}
