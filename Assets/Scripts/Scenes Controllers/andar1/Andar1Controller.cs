﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar1Controller : MonoBehaviour {

    public GameObject[] barriers;
    public Steps[] steps;
    public int vidas = 3;
    public bool morto;
    public CardGenerator cardGenerator;
    public MongosseteGenerator mongosseteGenerator;
    public DisqueteGenerator disqueteGenerator;
    public int inimigosVivos;
    public GameObject[] spawners;
    public GameObject player;
    public bool[] executado;
    public class Steps
    {
        public bool beginned;
        public bool finished;
        public Steps(bool beginned, bool finished)
        {
            this.beginned = beginned;
            this.finished = finished;
        }
    }



	// Use this for initialization
	void Start () {
        executado = new bool[] { false,false,false,false};
        morto = false;
        steps = new[] {
            new Steps(false, false),
            new Steps(false, false),
            new Steps(false, false),
            new Steps(false, false)
        };
        if (!executado[0])
        {
            for (int i = 30; i <= 32; i++)
                FindObjectOfType<talks>().Falar(i);
            executado[0] = true;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(morto && vidas > 0)
        {
            for (int i = 0; i < steps.Length ; i++)
                if (steps[i].beginned && !steps[i].finished)
                {
                    player.SetActive(true);
                    player.transform.position = new Vector3(spawners[i].transform.position.x, spawners[i].transform.position.y, spawners[i].transform.position.z);
                    player.GetComponent<Datas>().principais.health = player.GetComponent<Datas>().principais.maxHealth;
                    player.GetComponent<Datas>().principais.inControl = true;
                }
            morto = false;
            vidas--;
        }

        if (!barriers[0])
        {
            steps[0].beginned = true;
            cardGenerator.able = true;
            steps[0].finished = false;
        }

        if (cardGenerator.maxCards < cardGenerator.generatedCards && cardGenerator.vivo <= 0)
        {
            steps[0].finished = true;
            barriers[1].SetActive(false);
            
            
        }
        if (!executado[1] && steps[0].finished)
        {
            for (int i = 36; i <= 39; i++)
                FindObjectOfType<talks>().Falar(i);
            executado[1] = true;
        }
        if (!barriers[2])
        {
            barriers[1].SetActive(true);
            steps[1].beginned = true;
            mongosseteGenerator.able = true;
        }

        if (mongosseteGenerator.maxMongossetes < mongosseteGenerator.generatedMongossetes && mongosseteGenerator.vivo <= 0)
        {
            steps[1].finished = true;
            barriers[3].SetActive(false);
        }
        if (!executado[2] && steps[1].finished)
        {
            for (int i = 40; i <= 41; i++)
                FindObjectOfType<talks>().Falar(i);
            executado[2] = true;
        }

        if (!barriers[4])
        {
            barriers[3].SetActive(true);
            steps[2].beginned = true;
            disqueteGenerator.able = true;
        }

        if (disqueteGenerator.maxDisquetes < disqueteGenerator.generatedDisquetes && disqueteGenerator.vivo <= 0)
        {
            steps[2].finished = true;
            barriers[35].SetActive(false);            
        }

        if (!executado[3] && steps[2].finished)
        {
            for (int i = 42; i <= 44; i++)
                FindObjectOfType<talks>().Falar(i);
            executado[3] = true;
        }
        if (!barriers[6])
        {
            barriers[5].SetActive(true);
            steps[3].beginned = true;
            disqueteGenerator.able = true;
        }

        if (steps[0].beginned && !steps[0].finished)
            inimigosVivos = cardGenerator.maxCards - cardGenerator.generatedCards + cardGenerator.vivo;
        if (steps[1].beginned && !steps[1].finished)
            inimigosVivos = mongosseteGenerator.maxMongossetes - mongosseteGenerator.generatedMongossetes + mongosseteGenerator.vivo;
        if (steps[2].beginned && !steps[2].finished)
            inimigosVivos = disqueteGenerator.maxDisquetes - disqueteGenerator.generatedDisquetes + disqueteGenerator.vivo;
        if (steps[3].beginned && !steps[3].finished)
            inimigosVivos = 1;
    }
}
