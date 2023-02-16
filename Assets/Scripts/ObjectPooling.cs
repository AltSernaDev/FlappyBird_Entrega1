using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooling ObjPoolCode;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        ObjPoolCode = this;
    }

    private void Start()
    {
        poolDictionary= new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject objFromPool = Instantiate(pool.prefab);
                objFromPool.SetActive(false);
                objectPool.Enqueue(objFromPool);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos,Quaternion rot)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation=rot;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
