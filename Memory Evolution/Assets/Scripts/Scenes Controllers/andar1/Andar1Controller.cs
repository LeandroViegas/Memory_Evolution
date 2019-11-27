using System;
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
        morto = false;
        steps = new[] {
            new Steps(false, false),
            new Steps(false, false),
            new Steps(false, false)
        };
	}
	
	// Update is called once per frame
	void Update () {
        if(morto && vidas > 0)
        {
            for (int i = 0; i < steps.Length ; i++)
                if (steps[i].beginned && !steps[i].finished)
                {
                    player.SetActive(true);
                    morto = false;
                    player.transform.position = new Vector3(spawners[i].transform.position.x, spawners[i].transform.position.y, spawners[i].transform.position.z);
                    player.GetComponent<Datas>().principais.health = player.GetComponent<Datas>().principais.maxHealth;
                    player.GetComponent<Datas>().principais.inControl = true;
                    vidas--;
                }
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

        if (!barriers[4])
        {
            barriers[3].SetActive(true);
            steps[2].beginned = true;
            disqueteGenerator.able = true;
        }

        if (steps[0].beginned && !steps[0].finished)
            inimigosVivos = cardGenerator.maxCards - cardGenerator.generatedCards + cardGenerator.vivo;
        if (steps[1].beginned && !steps[1].finished)
            inimigosVivos = mongosseteGenerator.maxMongossetes - mongosseteGenerator.generatedMongossetes + mongosseteGenerator.vivo;
        if (steps[2].beginned && !steps[2].finished)
            inimigosVivos = disqueteGenerator.maxDisquetes - disqueteGenerator.generatedDisquetes + disqueteGenerator.vivo;
    }
}
