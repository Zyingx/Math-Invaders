using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public AudioSource ExplodeSound;
    public GameObject[] nijja;

    void Start()
    {
        ExplodeSound = GetComponent<AudioSource>();
        nijja = GameObject.FindGameObjectsWithTag("SmallPP");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>().worth == nijja[0].GetComponent<Equations>().FinalAnswer)
        {
            nijja[0].GetComponent<Equations>().AchieveAnswer = true;
        }
        else
        {
            nijja[0].GetComponent<Equations>().EnemyKilled++;
        }
        Destroy(collision.gameObject);
        PlayLaser();
        Destroy(this.gameObject);
    }

    void PlayLaser()
    {
        ExplodeSound.Play();
    }
}