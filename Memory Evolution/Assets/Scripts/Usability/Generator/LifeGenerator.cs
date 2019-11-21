using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGenerator : MonoBehaviour {

    GameObject[] lifes;
    List<ObjectGenerator> childs;
    public GameObject life;
    float timer = 2f;
    int maxLifes = 10;
    int generatedLifes = 0;
    int vivo = 0;
    // Use this for initialization
    void Start()
    {
        lifes = new GameObject[maxLifes];
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;
        vivo = 0;
        foreach (GameObject aLife in lifes)
            if (aLife)
                vivo++;
        if (timer <= 0 && vivo < 3 && generatedLifes < maxLifes && FindObjectOfType<CardGenerator>().vivo > 0)
        {
            bool end = false;
            for (int i = 0; i < lifes.Length && !end; i++)
            {
                if (!lifes[i])
                {
                    int pos = Random.Range(0, transform.childCount);
                    transform.GetChild(pos).GetComponent<ObjectGenerator>().objeto = life;
                    GameObject child = transform.GetChild(pos).GetComponent<ObjectGenerator>().GenerateObject();
                    generatedLifes++;
                    lifes[i] = child;
                    end = true;
                }
            }
            timer = 5f;
        }
    }
}
