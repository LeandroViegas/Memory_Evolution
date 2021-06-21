using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongosseteGenerator : MonoBehaviour {

    GameObject[] mongossetes;
    List<ObjectGenerator> childs;
    public GameObject enemy;
    float timer = 2f;
    public int maxMongossetes = 10;
    public int generatedMongossetes = 0;
    public int vivo = 0;
    public bool able = false;
    // Use this for initialization
    void Start()
    {
        mongossetes = new GameObject[maxMongossetes];
    }

    // Update is called once per frame
    void Update()
    {
        if (able)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
                timer = 0;
            vivo = 0;
            foreach (GameObject card in mongossetes)
                if (card)
                    vivo++;
            if (timer <= 0 && vivo < 3 && generatedMongossetes < maxMongossetes)
            {
                bool end = false;
                for (int i = 0; i < mongossetes.Length && !end; i++)
                {
                    if (!mongossetes[i])
                    {
                        int pos = Random.Range(0, transform.childCount);
                        transform.GetChild(pos).GetComponent<ObjectGenerator>().objeto = enemy;
                        GameObject child = transform.GetChild(pos).GetComponent<ObjectGenerator>().GenerateObject();
                        generatedMongossetes++;
                        mongossetes[i] = child;
                        end = true;
                    }
                }
                timer = 5f;
            }
        }  
    }
}
