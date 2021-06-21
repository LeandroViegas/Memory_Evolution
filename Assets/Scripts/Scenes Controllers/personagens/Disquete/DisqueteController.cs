using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisqueteController : MonoBehaviour {


    // Atack Booleans
    public bool inAtack = false;
    bool AlertAtack = false;

    //Basic Atacks Variables
    Vector3 atackInicialPosition;
    Vector3 directionVector;
    public Datas dados;
    public GameObject Enemy = null;
    public GameObject disqueteBulletPrefab;

    // Walk Variables
    public bool wallCollision = false;
    float speed = 8f;
    float TimerToWalk = 5f;
    Vector3 MyPosition;
    Vector3 MyDestination;
    public Rigidbody2D rg2d;
    // Use this for initialization
    void Start () {
        dados = GetComponent<Datas>();
        rg2d = GetComponent<Rigidbody2D>();
        DestinationGenerator();
    }
	
	// Update is called once per frame
	void Update () {
        if (!AlertAtack)
        {
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
            dados.combatStats.damageRemaining = Random.Range(1f, 3f);
            Vector2 direction = (Vector2)((Enemy.transform.position - transform.position));
            direction.Normalize();

            GameObject bullet = (GameObject)Instantiate(
                                            disqueteBulletPrefab,
                                            transform.position + (Vector3)(direction * 0.5f),
                                            Quaternion.identity);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<CapsuleCollider2D>());
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<CircleCollider2D>());
            Destroy(bullet, 0.8f);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 20f;
            bullet.GetComponent<DisqueteBullet>().available = true;
        }
        rg2d.MovePosition(Vector2.MoveTowards(transform.position, Enemy.transform.position, Time.deltaTime * 2f));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletController>())
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                Enemy = collision.gameObject;
        if (collision.GetComponent<BulletController>())
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletController>())
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
        if (collision.gameObject.GetComponent<Datas>())
            if (collision.gameObject.GetComponent<Datas>().team.player)
            {
                Enemy = collision.gameObject;
                inAtack = true;
            }
        if (collision.GetComponent<BulletController>())
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
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
            if (!collision.gameObject.GetComponent<Datas>().collision.collision)
                Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
            else
                wallCollision = true;
        }
        if (collision.gameObject.GetComponent<DisqueteController>() != null)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
    }
}
