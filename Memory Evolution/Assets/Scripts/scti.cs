using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scti : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<EntradaController>().SolicitarFala(0);
    }
}
