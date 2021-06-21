using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damage(float dano)
    {
        Datas dados = GetComponent<Datas>();
        if(dano > dados.principais.health)
            dados.principais.health = 0;
        else if ( dano > 0)
            dados.principais.health -= dano;
    }
}
