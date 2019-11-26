using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar1Controller : MonoBehaviour {

    public GameObject[] barriers;
    public Steps[] steps;
    int vidas = 3;
    public CardGenerator cardGenerator;
    public MongosseteGenerator mongosseteGenerator;
    public int inimigosVivos;
    public GameObject[] spawners;
    public GameObject playerPrefab;
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
        steps = new[] {
            new Steps(false, false),
            new Steps(false, false),
            new Steps(false, false)
        };
	}
	
	// Update is called once per frame
	void Update () {
        if(!player)
        {
            bool ver = false;
            for (int i = 0; i < steps.Length && !ver; i++)
                if (steps[i].beginned && steps[i].finished)
                {
                    player = Instantiate(playerPrefab);
                    player.transform.position = new Vector3(spawners[i].transform.position.x, spawners[i].transform.position.y, spawners[i].transform.position.z);
                    FindObjectOfType<CameraFollow>().Target = player.transform;
                    ver = true;
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
            Destroy(barriers[1]);
        }
        if (!barriers[2])
        {
            steps[1].beginned = true;
            mongosseteGenerator.able = true;
        }
        if(steps[0].beginned && !steps[0].finished)
            inimigosVivos = cardGenerator.maxCards - cardGenerator.generatedCards + cardGenerator.vivo;
        if (steps[1].beginned && !steps[1].finished)
            inimigosVivos = mongosseteGenerator.maxMongossetes - mongosseteGenerator.generatedMongossetes + mongosseteGenerator.vivo;
    }
}
