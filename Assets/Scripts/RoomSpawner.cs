using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 bottom door
    // 2 top door
    // 3 left door
    // 4 right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    public int spawnedCounter = 0;
    public int levelCounter = 0;
    // public SpawnedRoomCount count;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()

    {

        if (spawned == false)
        {
            if (LevelCounter.instance.levelCount >= SpawnedRoomCount.instance.roomCount)
            {
                if (openingDirection == 1)
                {
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                }
                else if (openingDirection == 2)
                {
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                }
                else if (openingDirection == 3)
                {
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                }
                else if (openingDirection == 4)
                {
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                }
                spawned = true;
                SpawnedRoomCount.instance.roomCount++;
                Debug.Log(SpawnedRoomCount.instance.roomCount);
            }

            else
            {
                Debug.Log("Reached the number");
                if (openingDirection == 1)
                {
                    rand = Random.Range(0, templates.endBottomRooms.Length);
                    Instantiate(templates.endBottomRooms[rand], transform.position, templates.endBottomRooms[rand].transform.rotation);
                }
                else if (openingDirection == 2)
                {
                    rand = Random.Range(0, templates.endTopRooms.Length);
                    Instantiate(templates.endTopRooms[rand], transform.position, templates.endTopRooms[rand].transform.rotation);
                }
                else if (openingDirection == 3)
                {
                    rand = Random.Range(0, templates.endLeftRooms.Length);
                    Instantiate(templates.endLeftRooms[rand], transform.position, templates.endLeftRooms[rand].transform.rotation);
                }
                else if (openingDirection == 4)
                {
                    rand = Random.Range(0, templates.endRightRooms.Length);
                    Instantiate(templates.endRightRooms[rand], transform.position, templates.endRightRooms[rand].transform.rotation);
                }
            }

        }

        spawnedCounter++;
        // count.roomCount++;
        // SpawnedRoomCount.instance.roomCount++;
        // Debug.Log(spawnedCounter);
        // Debug.Log(count.roomCount);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);

                // Debug.Log("I DESTROYED SOMETHING");
            }
            spawned = true;

        }
    }
}


