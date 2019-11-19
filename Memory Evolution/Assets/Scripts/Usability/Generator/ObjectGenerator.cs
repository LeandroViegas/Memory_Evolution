using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    BoxCollider2D boxCol;
    public GameObject objeto;
    // Use this for initialization
    void Start () {
        boxCol = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	public GameObject GenerateObject() {
        return Instantiate(objeto, new Vector3(Random.Range((transform.position.x /*- boxCol.offset.x*/) - (boxCol.size.x / 2), (transform.position.x /*- boxCol.offset.x*/) + (boxCol.size.x / 2)), Random.Range((transform.position.y/* - boxCol.offset.y*/) - (boxCol.size.y / 2), (transform.position.y/* - boxCol.offset.y*/) + (boxCol.size.y / 2)), 0f), Quaternion.identity);    
    }
}
