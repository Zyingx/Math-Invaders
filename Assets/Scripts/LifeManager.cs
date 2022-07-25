using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;
    private int lifeCounter;

    private Text wordText;
    
    // Start is called before the first frame update
    void Start()
    {
        wordText = GetComponent<Text>();


        lifeCounter = startingLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCounter < 0)
        {

        }

        wordText.text = "Lives : " + lifeCounter;
    }

    void Hurt()
    {
        lifeCounter--;
    }
}
