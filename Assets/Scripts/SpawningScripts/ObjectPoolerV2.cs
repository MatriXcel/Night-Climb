using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    [Tooltip(@"Name is used to differ the objects from one another")]
    public string name;

    [Tooltip(@"What object should be created ?")]
    public GameObject obj;

    [Range(1, 10000)]
    [Tooltip(@"How much objects should be created ?")]
    public int amount;

    [Tooltip(@"Can new objects be created in case there are none left ?")]
    public bool canGrow;

    [Tooltip(@"False - objects must be created manually using Populate method
True - objects will be created automatically on awake")]
    public bool createOnAwake;
}


public class ObjectPoolerV2 : MonoBehaviour
{


    public PooledObject[] ObjectsToPool;

    private readonly Dictionary<string, List<GameObject>> pooledObjects =
        new Dictionary<string, List<GameObject>>();


    private readonly Dictionary<string, PooledObject> pooledObjectsContainer =
        new Dictionary<string, PooledObject>();

    private void Awake()
    {
        foreach (PooledObject objectToPool in ObjectsToPool)
        {
            pooledObjects.Add(objectToPool.name, new List<GameObject>());
            pooledObjectsContainer.Add(objectToPool.name, objectToPool);


            if (objectToPool.createOnAwake)
            {
                populate(objectToPool.name);
            }
        }
    }

    public void populate(string objectName)
    {
        pooledObjects[objectName].Clear();


        for (int i = 0; i < pooledObjectsContainer[objectName].amount; i++)
        {
            GameObject obj = Instantiate(pooledObjectsContainer[objectName].obj);
            obj.SetActive(false);
            pooledObjects[objectName].Add(obj);
        }
    }


    public GameObject getPooledObject(string objectName)
    {
        for (int i = 0; i < pooledObjects[objectName].Count; i++)
        {
            if (!pooledObjects[objectName][i].activeInHierarchy)
            {
                return pooledObjects[objectName][i];
            }
        }
        if (pooledObjectsContainer[objectName].canGrow)
        {
            GameObject obj = Instantiate(pooledObjectsContainer[objectName].obj);
            pooledObjects[objectName].Add(obj);
            return obj;
        }

        return null;
    }

}
