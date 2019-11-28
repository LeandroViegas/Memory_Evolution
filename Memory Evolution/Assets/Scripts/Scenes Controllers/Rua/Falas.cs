using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falas : MonoBehaviour {

    bool executed = false;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if(executed == false)
        {
            for(int i = 2; i <= 28; i++)
                FindObjectOfType<talks>().Falar(i);
            executed = true;
        }
        if (FindObjectOfType<talks>().falas[15].talked > 0)
            FindObjectOfType<PlayerController>().GetComponent<Datas>().combatStats.atack = true; 
    }
}
