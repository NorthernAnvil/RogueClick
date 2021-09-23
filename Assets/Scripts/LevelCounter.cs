using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [CreateAssetMenu(menuName = "ScriptibleObjects/roomCount")]
public class LevelCounter : MonoBehaviour
{
    public int levelCount = 10;
    public static LevelCounter instance;

    private void Awake()
    {
        instance = this;
        levelCount = 500;
    }
}
