using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {

    GameObject[] cards;
    List<ObjectGenerator> childs;
    public GameObject enemy;
    float timer = 5f;
    int maxCards = 10;
	// Use this for initialization
	void Start () {
        cards = new GameObject[maxCards];
        /*childs = new List<ObjectGenerator>();
        for (int i = 0; i < transform.childCount; i++)
        {
            childs.Add();
        }*/
    }

    /* && FindObjectsOfType<life>().Length < 3 && FindObjectOfType<cardGenerator>().generated < FindObjectOfType<cardGenerator>().maxGenerate*/

    // Update is called once per frame
    void Update () {
        if(timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;
        if(timer <= 0)
        {    
            bool end = false;
            for ( int i = 0; i < cards.Length && !end; i++)
            {
                if (!cards[i])
                {
                    int pos = Random.Range(0, transform.childCount);
                    transform.GetChild(pos).GetComponent<ObjectGenerator>().objeto = enemy;
                    GameObject child = transform.GetChild(pos).GetComponent<ObjectGenerator>().GenerateObject();
                    cards[i] = child;
                    end = true;
                }
            }
            timer = 5f;
        }
	}


}
