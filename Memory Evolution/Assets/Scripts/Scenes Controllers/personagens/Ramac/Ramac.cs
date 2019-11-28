using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramac : MonoBehaviour {

    public BoxCollider2D[] boxCols;
    public GameObject objeto;
    public Datas dados;
    public Vector3 position;
    float timer = 4f;
    // Use this for initialization
    void Start()
    {
        dados = GetComponent<Datas>();
        boxCols = GetComponentsInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            foreach (BoxCollider2D boxCol in boxCols)
            {
                position = new Vector3(Random.Range((boxCol.transform.position.x /*- boxCol.offset.x*/) - (boxCol.size.x / 2), (boxCol.transform.position.x /*- boxCol.offset.x*/) + (boxCol.size.x / 2)), Random.Range((boxCol.transform.position.y/* - boxCol.offset.y*/) - (boxCol.size.y / 2), (boxCol.transform.position.y/* - boxCol.offset.y*/) + (boxCol.size.y / 2)), 0f);
                Instantiate(objeto, new Vector3(transform.position.x + (GetComponent<BoxCollider2D>().size.x / 2), transform.position.y, transform.position.z), Quaternion.identity).GetComponent<BombRamac>().target = position;
            }
            timer = 4f;
        }
        timer -= Time.deltaTime;
        LifeManager();
        if (dados.principais.health == 0)
        {
            Destroy(gameObject);
        }
    }

    void LifeManager()
    {
        Transform Barra = transform.Find("LifeBar").transform.Find("Barra");
        Barra.localScale = new Vector2(dados.principais.health / dados.principais.maxHealth, Barra.localScale.y);
        if (dados.principais.health <= 0)
            Barra.localScale = new Vector2(0, Barra.localScale.y);
        if (dados.principais.health >= dados.principais.maxHealth)
            Barra.localScale = new Vector2(1, Barra.localScale.y);
    }
}
