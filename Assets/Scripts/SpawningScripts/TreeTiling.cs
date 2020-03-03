using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTiling : BaseTiling {

    public Vector3 rightTreeSpawn;
    public Vector3 leftTreeSpawn;

    public GameObject rightTree;
    public GameObject leftTree;

    public delegate void OnTreeSpawned();
    public event OnTreeSpawned onTreeSpawn;


    void Awake()
    {
        tileDisabled += treeDisabled;
    }

    protected override void Start()
    {
        base.Start();
        spriteHeight = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void treeDisabled()
    {
        
        GameObject previousEnemy = findObjectWithLayer(gameObject, "Enemy");
        GameObject coin = findObjectWithTag(gameObject, "Coin");

        if (previousEnemy != null)
            GameEntityManager.Instance.returnToPool(previousEnemy);

        if (coin != null)
            GameEntityManager.Instance.returnToPool(coin);

        GameObject powerup = findObjectWithLayer(transform.gameObject, "Powerup");
        if (powerup != null)
            GameEntityManager.Instance.returnToPool(powerup);

        rightTree.SetActive(false);
        leftTree.SetActive(false);

        GameEntityManager.Instance.returnToPool(rightTree);
        GameEntityManager.Instance.returnToPool(leftTree);
    }

    void OnEnable()
    {
        for (int i = 0; i < 2; i++) { 

            Vector3 spawnPoint;
           // string chosenkey = treeKeys[Random.Range(0, treeKeys.Count)];
            GameObject tree = GameEntityManager.Instance.getRandTree();

            if(i == 0)
            {
                rightTree = tree;
                spawnPoint = rightTreeSpawn;
                tree.tag = "rightTree";
            }
            else
            {
                leftTree = tree;
                spawnPoint = leftTreeSpawn;
                tree.tag = "leftTree";
            }
            tree.SetActive(true);

            tree.transform.parent = transform;
            tree.transform.localPosition = spawnPoint;
        }
       
        onTreeSpawn();
    }

    public GameObject findObjectWithTag(GameObject rootObject, string tag)
    {

        foreach (Transform childTransform in rootObject.transform)
        {
            if (childTransform.transform.tag == tag)
            {
                return childTransform.gameObject;
            }
        }
        return null;
    }

    public GameObject findObjectWithLayer(GameObject rootObject, string layerName)
    {
        foreach (Transform childTransform in rootObject.transform)
        {
            if (childTransform.gameObject.layer == LayerMask.NameToLayer(layerName))
            {
                return childTransform.gameObject;
            }
        }
        return null;
    }
}
