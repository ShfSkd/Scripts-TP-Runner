using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PoolTiles : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string type;
        public GameObject prefab;
        public int size;
    }

    #region Singelton
    public static PoolTiles instance;

    GameObject objectToSpawn;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictioanry;
    private void Start()
    {
        poolDictioanry = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictioanry.Add(pool.type, objectPool);
        }
    }
    public GameObject SpawnFromPool(string type, Vector3 position, Quaternion rotation)
    {
        if (!poolDictioanry.ContainsKey(type))
        {
            UnityEngine.Debug.LogWarning("Pool With Tag" + type + "DosentExist");
            return null;
        }

        objectToSpawn = poolDictioanry[type].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        

        poolDictioanry[type].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


}
