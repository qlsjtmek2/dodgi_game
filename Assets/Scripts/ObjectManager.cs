using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트 풀링
public class ObjectManager : MonoBehaviour
{
    public GameObject enemyRPrefab;

    GameObject[] enemyR;
    GameObject[] targetPool;

    void Awake()
    {
        enemyR = new GameObject[140];

        Generate();
    }

    void Generate()
    {
        // #1.Enemy
        for (int index = 0; index < enemyR.Length; index++)
        {
            enemyR[index] = Instantiate(enemyRPrefab);
            enemyR[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "EnemyR":
                targetPool = enemyR;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return enemyR[index];
            }
        }

        return null;
    }

    public GameObject[] getPool(string type)
    {
        switch (type)
        {
            case "EnemyR":
                targetPool = enemyR;
                break;
        }

        return targetPool;
    }
}
