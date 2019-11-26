using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiDatas : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform barra = transform.Find("datas").Find("life").Find("barrinha").GetComponent<Transform>();
        if(Player)
            barra.localScale = new Vector3(1 * Player.GetComponent<Datas>().principais.health / Player.GetComponent<Datas>().principais.maxHealth, barra.localScale.y, barra.localScale.z);
        else
            barra.localScale = new Vector3(0, barra.localScale.y, barra.localScale.z);

    }
}
