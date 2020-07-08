using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpwaner : MonoBehaviour
{
    [SerializeField] private float groundSpawnDistane = 50f;

    private bool spawningObject=false;

    public static ObjectSpwaner instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnGround()
    {
        PoolTiles.instance.SpawnFromPool("ground", new Vector3(0, 0, groundSpawnDistane), Quaternion.identity);
    }
}
