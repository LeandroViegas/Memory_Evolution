using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MongosseteController : MonoBehaviour
{

    //Basic Atacks Variables
    public Datas dados;
    public GameObject Enemy = null;
    public bool inAtack = false;
    public GameObject temporarySoco;
    public GameObject soco;
    public GameObject temporaryPuxe;
    public GameObject puxe;
    public float timeToAtack = 0f;

    // Walk Variables
    public bool wallCollision = false;
    float speed = 8f;
    float TimerToWalk = 5f;
    Vector3 MyPosition;
    Vector3 MyDestination;
    Rigidbody2D rg2d;
    // Use this for initialization
    void Start()
    {
        dados = GetComponent<Datas>();
        rg2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (temporaryPuxe)
        {
            if (temporaryPuxe.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                if(temporaryPuxe.GetComponent<puxar>().person)
                    temporaryPuxe.GetComponent<puxar>().person.GetComponent<Datas>().principais.inControl = true;
                Destroy(temporaryPuxe);
                temporaryPuxe = null;
                temporarySoco = Instantiate(soco, transform);
                if(Enemy)
                if (Enemy.transform.position.x < transform.position.x)
                {
                    temporarySoco.GetComponentInChildren<Transform>().localPosition = new Vector3(-1 * temporarySoco.transform.localPosition.x, temporarySoco.transform.localPosition.y, temporarySoco.transform.localPosition.z);
                    temporarySoco.GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
            }
        }
        if (temporarySoco)
        {
            if (temporarySoco.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                Destroy(temporarySoco);
                temporarySoco = null;
            }
        }

        if (wallCollision)
        {
            DestinationGenerator();
            wallCollision = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (!wallCollision)
            rg2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), MyDestination, Time.deltaTime * speed));

        if (TimerToWalk <= 0)
        {
            DestinationGenerator();
            TimerToWalk = Random.Range(4f, 6f);
        }
        if (Enemy != null)
        {
            rg2d.MovePosition(Vector2.MoveTowards(transform.position, Enemy.transform.position, Time.deltaTime * 4.2f));
            if (timeToAtack <= 0)
            {
                Socar();
                timeToAtack = 4f;
            }

        }


        timeToAtack -= Time.deltaTime;
        TimerToWalk -= Time.deltaTime;
        LifeManager();
        if (dados.principais.health == 0)
        {
            Destroy(gameObject);
        }
    }

    void LifeManager()
    {
        Transform Barra = transform.Find("LifeBar").transform.Find("Barra");
        Barra.localScale = new Vector2(dados.principais.health / 100, Barra.localScale.y);
        if (dados.principais.health <= 0)
            Barra.localScale = new Vector2(0, Barra.localScale.y);
        if (dados.principais.health >= 100)
            Barra.localScale = new Vector2(1, Barra.localScale.y);
    }

    public void Socar()
    {
        temporaryPuxe = Instantiate(puxe, transform);
        if (Enemy.transform.position.x < transform.position.x)
        {
            temporaryPuxe.transform.localPosition = new Vector3(-1 * temporaryPuxe.transform.localPosition.x, temporaryPuxe.transform.localPosition.y, temporaryPuxe.transform.localPosition.z);
            temporaryPuxe.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void DestinationGenerator()  
    {
        MyDestination = new Vector3(Random.Range(transform.position.x - 6f, transform.position.x + 6f), Random.Range(transform.position.y - 6f, transform.position.y + 6f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>())
            if (collision.gameObject.GetComponent<Datas>().team.player)
            {
                Enemy = collision.gameObject;
                inAtack = true;
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>())
            if (collision.gameObject.GetComponent<Datas>().team.player)
            {
                Enemy = collision.gameObject;
                inAtack = true;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>())
            if (collision.gameObject.GetComponent<Datas>().team.player)
            {
                Enemy = null;
                inAtack = false;
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>() != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
            if (!collision.gameObject.GetComponent<Datas>().collision.collision)
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
            else
                wallCollision = true;
        }
        if (collision.gameObject.GetComponent<MongosseteController>() != null)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
    }
}
