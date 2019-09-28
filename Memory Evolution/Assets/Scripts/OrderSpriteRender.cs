using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSpriteRender : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            if(renderer.gameObject.layer != 9)
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100);   
        }

        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.transform.parent != null)
            {
                if (renderer.gameObject.layer != 9)
                    renderer.sortingOrder = (int)(renderer.transform.parent.position.y * -100 - 1);
            }
        } 
    }
}
