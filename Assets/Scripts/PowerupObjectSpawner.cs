using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupObjectSpawner : MonoBehaviour
{
    [Range(0, 10)]
    public float threshold;

    void Awake()
    {
        GetComponent<TreeTiling>().onTreeSpawn += treeSpawned;
    }

    void treeSpawned()
    {
        float choice = Random.Range(0f, 10f);

        if(choice < threshold)
        {
            spawnPowerup();
        }
    }


    void spawnPowerup()
    {
        GameObject powerup = GameEntityManager.Instance.getRandPowerup();
        powerup.SetActive(true);
        powerup.transform.parent = transform;
        powerup.transform.localPosition = Vector3.zero;
    }
}
