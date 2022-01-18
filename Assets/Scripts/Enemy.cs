using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySpawn spawn;

    void Awake()
    {
        spawn = GameObject.Find("Enemy Spawn").GetComponent<EnemySpawn>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyBorder")
        {
            gameObject.SetActive(false);

            int bdr = Random.Range(0, 4);
            switch (bdr)
            {
                case 0:
                    spawn.RandomSpawn(spawn.borders[bdr], bdr);
                    break;
                case 1:
                    spawn.RandomSpawn(spawn.borders[bdr], bdr);
                    break;
                case 2:
                    spawn.RandomSpawn(spawn.borders[bdr], bdr);
                    break;
                case 3:
                    spawn.RandomSpawn(spawn.borders[bdr], bdr);
                    break;
            }
        }
    }
}
