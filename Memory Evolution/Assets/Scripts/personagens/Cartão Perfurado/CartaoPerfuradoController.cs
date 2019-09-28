using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaoPerfuradoController : MonoBehaviour
{



    // Atack Booleans
    public bool inAtack = false;
    bool AlertAtack = false;

    //Basic Atacks Variables
    Vector3 atackInicialPosition;
    Vector3 directionVector;
    public Datas dados;
    public GameObject Enemy = null;

    // Walk Variables
    bool wallCollision = false;
    float speed = 4f;
    float TimerToWalk = 5f;
    Vector3 MyPosition;
    Vector3 MyDestination;
    Rigidbody2D rg2d;


    void Start()
    {
        dados = GetComponent<Datas>();
        rg2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!AlertAtack)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (!wallCollision)
                rg2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), MyDestination, Time.deltaTime * speed));
            if (wallCollision)
            {
                DestinationGenerator();
                wallCollision = false;
            }
            if (TimerToWalk <= 0)
            {
                DestinationGenerator();
                TimerToWalk = 5f;
            }
            TimerToWalk -= Time.deltaTime;
        }

        if (Enemy != null)
            atackMode();
        else
            AlertAtack = false;

        if (dados.combatStats.damageRemaining > 0)
            dados.combatStats.damageRemaining -= Time.deltaTime;

        LifeManager();
        if (dados.principais.health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void DestinationGenerator()
    {
        MyDestination = new Vector3(Random.Range(transform.position.x - 6f, transform.position.x + 6f), Random.Range(transform.position.y - 6f, transform.position.y + 6f));
    }

    public void atackMode()
    {
        AlertAtack = true;
        
        if (dados.combatStats.damageRemaining <= 0)
        {
            dados.combatStats.damageRemaining = 4;
            if (Vector2.Distance(Enemy.transform.position, transform.position) <= 5)
            {
                atackInicialPosition = transform.position;
                var mousePosition = Enemy.transform.position;
                directionVector = (mousePosition - transform.position).normalized;
                inAtack = true;
            }
        }
        if (inAtack)
        {
            transform.Translate(directionVector * 15F * Time.deltaTime);
            if (Vector2.Distance(atackInicialPosition, transform.position) >= 4.5f || wallCollision)
                inAtack = false;
        }
        else
            rg2d.MovePosition(Vector2.MoveTowards(transform.position, Enemy.transform.position, Time.deltaTime * 2f));
    }

    void LifeManager()
    {
        Transform Barra = transform.Find("Sprite").transform.Find("LifeBar").transform.Find("Barra");
        Barra.localScale = new Vector2(dados.principais.health / 100, Barra.localScale.y);
        if (dados.principais.health <= 0)
            Barra.localScale = new Vector2(0, Barra.localScale.y);
        if (dados.principais.health >= 100)
            Barra.localScale = new Vector2(1, Barra.localScale.y);
    }
}
