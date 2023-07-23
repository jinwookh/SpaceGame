using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Point[] Points =
    {
        new Point(-3,-5), new Point(-3,-3), new Point(-3,-1), new Point(-3, 1), new Point(-3,3),
        new Point(-3, 5), new Point(3, -5), new Point(3, -3), new Point(3, -1), new Point(3,1),
        new Point(3,3), new Point(3,5),
    };
    public GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(GameObject prefab, Vector3 position)
    {
        GameObject enemy = Instantiate(prefab);
        enemy.transform.position = position;
        enemy.GetComponent<Enemy>().Move();
    }

    public void SpawnRandom()
    {
        Vector2 pos = Points[Random.Range(0, Points.Length)].GetPos();
        SpawnEnemy(EnemyPrefab, pos);
        Invoke("SpawnRandom", 1f);
    }
}
