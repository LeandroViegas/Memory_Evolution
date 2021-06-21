using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisqueteGenerator : MonoBehaviour {

    GameObject[] disquetes;
    List<ObjectGenerator> childs;
    public GameObject enemy;
    float timer = 2f;
    public int maxDisquetes = 10;
    public int generatedDisquetes = 0;
    public int vivo = 0;
    public bool able = false;
    // Use this for initialization
    void Start()
    {
        disquetes = new GameObject[maxDisquetes];
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
            foreach (GameObject disquete in disquetes)
                if (disquete)
                    vivo++;
            if (timer <= 0 && vivo < 3 && generatedDisquetes < maxDisquetes)
            {
                bool end = false;
                for (int i = 0; i < disquetes.Length && !end; i++)
                {
                    if (!disquetes[i])
                    {
                        int pos = Random.Range(0, transform.childCount);
                        transform.GetChild(pos).GetComponent<ObjectGenerator>().objeto = enemy;
                        GameObject child = transform.GetChild(pos).GetComponent<ObjectGenerator>().GenerateObject();
                        generatedDisquetes++;
                        disquetes[i] = child;
                        end = true;
                    }
                }
                timer = 5f;
            }
        }
    }
}
