using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public ObjectManager objectManager;
    public string[] enemyObjs;
    public GameObject[] borders;
    public int count = 22;
    int spawncount = 0;

    float speed = 200;

    void Awake()
    {
        enemyObjs = new string[] { "EnemyR" };
    }

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);
        if (speed < 500)
            speed += Time.deltaTime * 4;
    }

    void Spawn()
    {
        InvokeRepeating("_spawn", 0.1f, 0.1f);
    }

    void _spawn()
    {
        if (spawncount >= count)
            CancelInvoke("_spawn");

        foreach (GameObject border in borders)
        {
            switch (border.name)
            {
                case "Top":
                    RandomSpawn(border, 0);
                    break;
                case "Bottom":
                    RandomSpawn(border, 1);
                    break;
                case "Right":
                    RandomSpawn(border, 2);
                    break;
                case "Left":
                    RandomSpawn(border, 3);
                    break;
            }
        }

        spawncount++;
    }

    // Top = 0, Bottom = 1, Right = 2, Left = 3
    public void RandomSpawn(GameObject border, int bdr)
    {
        BoxCollider2D box = border.GetComponent<BoxCollider2D>();

        float size;
        if (bdr == 0 || bdr == 1) size = box.size.x / 2.0f; // Top or Bottom 이냐
        else size = box.size.y / 2.0f;

        GameObject enemy = objectManager.MakeObj(enemyObjs[0]);
        if (bdr == 0 || bdr == 1) 
            enemy.transform.position = new Vector3(Random.Range(-size, size), box.offset.y, 0f);
        else 
            enemy.transform.position = new Vector3(box.offset.x, Random.Range(-size, size), 0f);

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Vector2 randomVectorX = new Vector2(Random.Range(-0.7f, 0.7f), 0); // 방향 벡터에 더하는 X, Y 벡터
        Vector2 randomVectorY = new Vector2(0, Random.Range(-0.7f, 0.7f));

        /*
        enemy.transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
        rigid.velocity = transform.forward * speed;
        */

        switch (bdr)
        {
            case 0:
                rigid.AddForce((Vector2.down + randomVectorX) * speed, ForceMode2D.Impulse);
                break;
            case 1:
                rigid.AddForce((Vector2.up + randomVectorX) * speed, ForceMode2D.Impulse);
                break;
            case 2:
                rigid.AddForce((Vector2.left + randomVectorY) * speed, ForceMode2D.Impulse);
                break;
            case 3:
                rigid.AddForce((Vector2.right + randomVectorY) * speed, ForceMode2D.Impulse);
                break;
        }
    }

    /*
     
    private float getAngle(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }

    */
}
