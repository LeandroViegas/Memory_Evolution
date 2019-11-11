using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardGenerator : MonoBehaviour {

    public GameObject cartao;
    public int generated = 0;
    public int maxGenerate;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CartaoPerfuradoController[] cartoes = FindObjectsOfType<CartaoPerfuradoController>();
        if(generated < maxGenerate)
            if (cartoes.Length < 3)
                {
                    Instantiate(cartao, transform);
                    generated++;
                }
            
	}
}
