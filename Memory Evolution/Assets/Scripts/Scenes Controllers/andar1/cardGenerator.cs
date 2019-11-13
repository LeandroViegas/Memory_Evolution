using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardGenerator : MonoBehaviour {

    BoxCollider2D boxCol;
    public GameObject cartao;
    public int generated = 0;
    public int maxGenerate;
    // Use this for initialization
	void Start () {
        boxCol = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        CartaoPerfuradoController[] cartoes = FindObjectsOfType<CartaoPerfuradoController>();
        if(generated < maxGenerate)
            if (cartoes.Length < 3)
                {
                Instantiate(cartao, new Vector3(Random.Range(transform.position.x - (boxCol.size.x / 2), transform.position.x + (boxCol.size.x / 2)), Random.Range(transform.position.y - (boxCol.size.y / 2), transform.position.y + (boxCol.size.y / 2)), 0f), Quaternion.identity);
                    generated++;
                }
            
	}
}
