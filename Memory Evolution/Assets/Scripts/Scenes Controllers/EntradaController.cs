using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaController : MonoBehaviour {

    // Use this for initialization
    void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
    		

	}

    public void SolicitarFala(int fala)
    {
        string[] falas = { "Depois de duas horas de trabalho duro, foi muito bom eu tomar um copo de água." };
        if (!FindObjectOfType<talks>().falando)
            FindObjectOfType<talks>().Falar(falas[fala]);
    }
}
