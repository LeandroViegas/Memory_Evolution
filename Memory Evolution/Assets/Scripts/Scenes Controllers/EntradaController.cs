using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaController : MonoBehaviour {

    public class Falas{
        public string personagem;
        public string fala;
    }

    public Falas[] falas;
    // Use this for initialization
	void Start () {
        falas[0].personagem = "izuna";
        falas[0].fala = "Bom dia meu caro";
    }
	
	// Update is called once per frame
	void Update () {
    		

	}

    public void Falar(int fala)
    {
        if (!FindObjectOfType<talks>().falando)
            FindObjectOfType<talks>().Falar(falas[fala].fala);
    }
}
