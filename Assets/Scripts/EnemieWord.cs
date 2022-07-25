using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemieWord : MonoBehaviour
{
    public EnemyController Lmao;
    public GameObject[] gate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Lmao == null)
        {
            gate = GameObject.FindGameObjectsWithTag("EnemyShip");
            for (int i = 0; i < gate.Length; i++)
            {
                if(gate[i].GetComponent<EnemyController>().notsingle == false)
                {
                    gate[i].GetComponent<EnemyController>().notsingle = true;
                    Lmao = gate[i].GetComponent<EnemyController>();
                    break;
                }
            }
            if (Lmao == null)
            {
                this.gameObject.GetComponent<Text>().text = null;
            }
        }
        else
        {
            var sxpstn = Camera.main.WorldToScreenPoint(Lmao.gameObject.transform.position);
            transform.position = sxpstn;
            this.gameObject.GetComponent<Text>().text = Lmao.worth.ToString();
        }

        
    }
}
