using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public GameObject sombra;
    public bool moveTop = false;
    public float distance = 0f;
    
    // Use this for initialization
    void Start()
    {
        if(GetComponentInParent<Transform>().Find("sombra").gameObject != null)
        sombra = GetComponentInParent<Transform>().Find("sombra").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (distance > 0.8f)
        {
            moveTop = false;
        }
        if (distance < 0.4f)
        {
            moveTop = true;
        }    
        if (moveTop)
            distance = distance + (Time.deltaTime * 2);
        if (!moveTop)
            distance = distance - (Time.deltaTime * 2);
        sombra.transform.localScale = new Vector3(distance*2, sombra.transform.localScale.y);
        transform.localPosition = new Vector2(0.031f, (distance * 1.9f)-0.8f);

    }
}