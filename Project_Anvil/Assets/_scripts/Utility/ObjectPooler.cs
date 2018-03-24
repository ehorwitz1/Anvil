using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Use this for initialization
    void Start () {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // loops placing all objects in the pool and setting them to inactive
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // SpawnFromPool //
    // gets an object from the pool and dequeues it for activating and moving to position needed, then returns it to the
    // object pool for future use if needed
    public GameObject SpawnFromPool(string _tag, Vector3 _position, Quaternion _rot)
    {
        
        if (!poolDictionary.ContainsKey(_tag))
        {
            Debug.Log("there isnt anything in the dictionary with tag: " + _tag);
            return null;
        }

        GameObject objectToSpawn  = poolDictionary[_tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = _position;
        objectToSpawn.transform.rotation = _rot;

        poolDictionary[_tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
