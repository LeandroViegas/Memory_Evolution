using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    BoxCollider2D boxCol;
    GameObject Enemy;
    public float timer = 5f;
    // Use this for initialization
    void Start () {
        boxCol = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInParent<ScriptableObject>().)
        {
            Instantiate(Enemy, new Vector3(Random.Range((transform.position.x - boxCol.offset.x) - (boxCol.size.x / 2), (transform.position.x - boxCol.offset.x) + (boxCol.size.x / 2)), Random.Range((transform.position.y - boxCol.offset.y) - (boxCol.size.y / 2), (transform.position.y - boxCol.offset.y) + (boxCol.size.y / 2)), 0f), Quaternion.identity);
        }
    }
}
