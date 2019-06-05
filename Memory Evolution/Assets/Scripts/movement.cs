using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{ 
    public float speed = 1.5f;
    private Vector3 target;
    var old_pos : float;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            var shootDir = new Vector3(transform.position.x - target.x, transform.position.y - target.y, transform.position.z - target.z);
            shootDir.Normalize();
            old_pos = transform.position.x;
        }        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
