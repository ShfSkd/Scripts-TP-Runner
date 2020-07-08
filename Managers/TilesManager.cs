using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] GameObject[] tilesPrefab;
    [SerializeField] float zSpawn = 0f;
    [SerializeField] float tileLength=30f;
    [SerializeField] int numberOfTiles = 5;
    [SerializeField] Transform playerTransform;


    private List<GameObject> activeTiles = new List<GameObject>();
    

    private void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTils(0);
            else
                SpawnTils(UnityEngine.Random.Range(0,tilesPrefab.Length));

        }
    }
    private void Update()
    {
        if (playerTransform.position.z > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTils(UnityEngine.Random.Range(0, tilesPrefab.Length));
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0],3f);
        activeTiles.RemoveAt(0);
    }

    public void SpawnTils(int tileIndex)
    {
        GameObject go= Instantiate(tilesPrefab[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go );
        zSpawn += tileLength;
        
    }
    

}
