using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [CreateAssetMenu(menuName = "ScriptibleObjects/roomCount")]
public class SpawnedRoomCount : MonoBehaviour
{
    public int roomCount = 0;
    public static SpawnedRoomCount instance;

    private void Awake()
    {
        instance = this;
        roomCount = -1;
    }
}


