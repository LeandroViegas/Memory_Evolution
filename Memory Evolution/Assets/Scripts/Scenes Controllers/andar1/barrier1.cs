using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        cardGenerator card = FindObjectOfType<cardGenerator>();
        CartaoPerfuradoController[] cartao = FindObjectsOfType<CartaoPerfuradoController>();
        if (card.generated >= card.maxGenerate && !(cartao.Length >= 1))
            Destroy(gameObject);
    }
}
