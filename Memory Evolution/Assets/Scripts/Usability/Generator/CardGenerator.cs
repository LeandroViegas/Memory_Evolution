using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {

    GameObject[] cards;
    List<ObjectGenerator> childs;
    public GameObject enemy;
    float timer = 2f;
    public int maxCards = 10;
    public int generatedCards = 0;
    public int vivo = 0;
    public bool able = false;
    // Use this for initialization
	void Start () {
        cards = new GameObject[maxCards];
    }

    // Update is called once per frame
    void Update () {
        if (able)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
                timer = 0;
            vivo = 0;
            foreach (GameObject card in cards)
                if (card)
                    vivo++;
            if (timer <= 0 && vivo < 3 && generatedCards < maxCards)
            {
                bool end = false;
                for (int i = 0; i < cards.Length && !end; i++)
                {
                    if (!cards[i])
                    {
                        int pos = Random.Range(0, transform.childCount);
                        transform.GetChild(pos).GetComponent<ObjectGenerator>().objeto = enemy;
                        GameObject child = transform.GetChild(pos).GetComponent<ObjectGenerator>().GenerateObject();
                        generatedCards++;
                        cards[i] = child;
                        end = true;
                    }
                }
                timer = 5f;
            }
        }     
	}
}
