using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    private int tilesSinceTile10 = 0;

    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0); //spawn initial tile at the start
            else
                SpawnTile(Random.Range(0, 9));
        }
    }

    void Update()
    {
        if(playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            if (tilesSinceTile10 >= 15) //to spawn power up tiles after 15 normal tiles
            {
                SpawnTile(9); //spawn tile with power up
                tilesSinceTile10 = 0; //reset back to 0
            }
            else
            {
                SpawnTile(Random.Range(0, 9)); //spawn normal tiles
                tilesSinceTile10 ++;
            }
            DeleteTile(); //delete tiles thay player has passed through
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
