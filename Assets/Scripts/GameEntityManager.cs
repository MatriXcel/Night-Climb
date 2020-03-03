using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntityManager : MonoBehaviour {

    public ObjectPoolerV2 objectPool;

    List<string> enemyKeys;
    List<string> powerupKeys;
    List<string> treeKeys;
    //static GameEntityManager _instance;
    public static GameEntityManager Instance{ get; private set; }
    

    void Awake()
    {
        Instance = this;
        enemyKeys = new List<string> { "SpikesSpinner", "Lizard", "HoleCreature" ,"Mushrooms", "Spider"};
        powerupKeys = new List<string> {"Lantern", "Grape", "Shield"}; 
        treeKeys = new List<string> { "TreePiece", "TreePiece 1", "TreePiece 2", "TreePiece 3" };
    }
   
    public void returnToPool(GameObject treeObject)
    {
        treeObject.transform.parent = transform;
        treeObject.SetActive(false);
    }


    public GameObject getRandPowerup()
    {
        GameObject powerup = objectPool.getPooledObject(powerupKeys[Random.Range(0, powerupKeys.Count)]);
        return powerup;
    }

    public GameObject getRandEnemy()
    {
        GameObject enemy = objectPool.getPooledObject(enemyKeys[Random.Range(0, enemyKeys.Count)]);
        return enemy;
    }

    public GameObject getCoin()
    {
        GameObject coin = objectPool.getPooledObject("Coin");
        return coin;
    }

    public GameObject getRandTree()
    {
        GameObject tree = objectPool.getPooledObject(treeKeys[Random.Range(0, treeKeys.Count)]);
        return tree;
    }
     
}
    