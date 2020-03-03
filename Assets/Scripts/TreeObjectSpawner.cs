using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TreeObjectSpawner : MonoBehaviour
{
    static float threshold;


    float treeSpriteWidthExtend;

    TreeTiling treeTiling;

    void Awake()
    {
        treeTiling = GetComponent<TreeTiling>();

        MilestoneManager.Instance.mileStoneReached += onMileStoneReached;
        GetComponent<TreeTiling>().onTreeSpawn += treeSpawned;
    }

    void onMileStoneReached(Difficulty diff)
    {
        threshold = diff.enemyThreshold;
    }

    void treeSpawned()
    {
        treeSpriteWidthExtend = treeTiling.rightTree.GetComponent<SpriteRenderer>().bounds.size.x / 2;     
        RandomizeObject();
    }

    public void RandomizeObject()
    {
        float choice = Random.value;
        string enemySpawn = string.Empty;

        if(choice < threshold)
        {
            if (Random.Range(0, 2) == 0)
                enemySpawn = "left";
            else
                enemySpawn = "right";
        }

        if(enemySpawn != string.Empty)
        {
            spawnEnemy(enemySpawn);
            if (Random.Range(0, 2) == 0)
                spawnCoin((enemySpawn == "right") ? "left" : "right");
        }
        else
        {
            if (Random.Range(0, 2) == 0)
                spawnCoin((Random.Range(0, 2) == 0) ? "right" : "left");
        }
    }

    void positionObject(GameObject spawn, string tree)
    {
        Vector3 pos;
        int scale;
        float enemySpriteWidthExtend;

       
        enemySpriteWidthExtend = spawn.GetComponent<SpriteRenderer>().bounds.size.x / 2;


        if (tree == "left")
        {
            pos = treeTiling.leftTree.transform.position + new Vector3(treeSpriteWidthExtend + enemySpriteWidthExtend - 0.2f, 0, 0);
            scale = -1;
        }
        else
        {
            pos = treeTiling.rightTree.transform.position + new Vector3(-treeSpriteWidthExtend - enemySpriteWidthExtend, 0, 0);
            scale = 1;
        }

        spawn.transform.position = pos;


        spawn.transform.localScale = new Vector3(scale * Mathf.Abs(spawn.transform.localScale.x), spawn.transform.localScale.y, spawn.transform.localScale.z);
    }

    public void spawnEnemy(string tree)
    {
        GameObject enemy = GameEntityManager.Instance.getRandEnemy();
        
        positionObject(enemy, tree);
        enemy.transform.parent = transform;

        enemy.SetActive(true);

    }

    public void spawnCoin(string tree)
    {
        GameObject coin = GameEntityManager.Instance.getCoin();
        coin.SetActive(true);
        coin.GetComponent<SpriteRenderer>().enabled = true;
        coin.transform.parent = transform;
        positionObject(coin, tree);
    }

    
}







