using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] EnemyShip;
    public Vector2 limit;
    public float Waiting;
    float maxi = 3;
    float mini = 2;
    public int Starting;
    public bool stop;

    int randomenemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        Waiting = Random.Range(mini, maxi);
    }

    IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds (Starting);

        while (!stop)
        {
            randomenemy = Random.Range(0, 7);

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            Vector2 spawnposition = new Vector2(Random.Range(min.x, max.x), max.y);

            Instantiate(EnemyShip[randomenemy], spawnposition, gameObject.transform.rotation);

            yield return new WaitForSeconds(Waiting);
        }
    }
}
