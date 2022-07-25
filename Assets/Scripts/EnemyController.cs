using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed;
    public int worth;
    public bool notsingle;
    public int luckynumber = 0;
    GameObject[] nijja;

    // Start is called before the first frame update
    void Start()
    {
        nijja = GameObject.FindGameObjectsWithTag("SmallPP");
        if ((int)Random.Range(0, 101) <= luckynumber)
        {
            worth = nijja[0].GetComponent<Equations>().FinalAnswer;
        }
        else
        {
            worth = Random.Range(-99, 99);
        }
        speed = 0.5f + ((float)nijja[0].GetComponent<Equations>().EnemyKilled / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pstn = transform.position;

        pstn = new Vector2(pstn.x, pstn.y - speed * Time.deltaTime);

        transform.position = pstn;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerShip"))
        {
            nijja[0].GetComponent<Equations>().Lives--;
            Destroy(this.gameObject);
        }
    }
}
