using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour {

    public GameObject Player;
    public GameObject Vida;
    public GameObject LifeText;
	// Use this for initialization
	void Start () {
        Vida = transform.GetChild(1).transform.GetChild(0).gameObject;
        LifeText = transform.GetChild(2).transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Player.GetComponent<Datas>().principais.health > 0)
            Vida.transform.localScale = new Vector2(Player.GetComponent<Datas>().principais.health / 100, transform.localScale.y);
        else
            Vida.transform.localScale = new Vector2(0 / 100, transform.localScale.y);
        LifeText.GetComponent<UnityEngine.UI.Text>().text = Player.GetComponent<Datas>().principais.health.ToString();
    }
}
