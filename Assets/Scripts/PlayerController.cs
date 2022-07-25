using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Shot;
    public GameObject ShotSpawn;
    public AudioSource LaserSound;
    public AudioClip Laser;

    public float ShotDelay = 0.25f;
    float coolTimer = 0;

    public float speed;

    public PauseMenu pmenu;

    void Start()
    {
        pmenu = FindObjectOfType<PauseMenu>();
    }

    void Update ()
    {
        coolTimer -= Time.deltaTime;

        if(Input.GetKey("space") && coolTimer <= 0)
        {
            coolTimer = ShotDelay;
            if (pmenu.GamePaused == false)
            {
                Spawn();
                PlayLaser();
            }
            
        }

        float x = Input.GetAxisRaw("Horizontal");

        Vector2 direction = new Vector2(x, 0f).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x += 0.225f;
        max.x -= 0.225f;

        Vector2 pstn = transform.position;

        pstn += direction * speed * Time.deltaTime;

        pstn.x = Mathf.Clamp(pstn.x, min.x, max.x);

        transform.position = pstn;
    }

    void PlayLaser()
    {
        LaserSound.PlayOneShot(Laser);
    }

    public void Spawn ()
    {
        GameObject shoot = (GameObject)Instantiate(Shot);
        shoot.transform.position = ShotSpawn.transform.position;
    }
}
