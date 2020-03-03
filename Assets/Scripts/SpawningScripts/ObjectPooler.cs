using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int pooledAmount;
    public GameObject parentObject;
    List<GameObject> pooledObjects;

 
    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            AddItem();
        }
	}

    public GameObject AddItem()
    {
        GameObject obj = Instantiate(pooledObject) as GameObject;
        obj.SetActive(false);
        obj.transform.parent = parentObject.transform;
        pooledObjects.Add(obj);
        return obj;
    }

    public GameObject getPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return AddItem();
    }






}
