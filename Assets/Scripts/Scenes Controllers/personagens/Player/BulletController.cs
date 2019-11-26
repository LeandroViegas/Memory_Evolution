﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public bool available;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null && available)
        {
            if (collision.GetComponent<Datas>().team.team2 == true)
            {
                if (collision.GetComponent<Actions>() != null)
                {
                    collision.GetComponent<Actions>().Damage(20);
                    available = false;
                    Destroy(gameObject, 0.09f);
                }
            }
            if(collision.GetComponent<Datas>().collision.collision)
                Destroy(gameObject, 0.09f);
        }
                      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null && available)
        {
            if (collision.GetComponent<Datas>().team.team2 == true)
            {
                if (collision.GetComponent<Actions>() != null)
                {
                    collision.GetComponent<Actions>().Damage(20);
                    available = false;
                    Destroy(gameObject, 0.09f);
                }
            }
            if (collision.GetComponent<Datas>().collision.collision)
                Destroy(gameObject, 0.09f);
        }
    }
}
