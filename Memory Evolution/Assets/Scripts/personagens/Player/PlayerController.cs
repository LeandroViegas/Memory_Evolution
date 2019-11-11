using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2d;
    Animator anim;
    SpriteRenderer SR;
    public GameObject magePrefab;
    public Datas datas;

    public float bulletVelocity = 20f;
    public float atackRemaining;
    public bool inAtack = false;

    void Start()
    {
        datas = GetComponent<Datas>();
        rg2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Datas>().principais.stamina > 0)
            GetComponent<Datas>().principais.stamina -= Time.deltaTime;
        if (datas.combatStats.damageRemaining > 0f)
            datas.combatStats.damageRemaining -= Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if (datas.principais.health <= 0)
            Destroy(gameObject);

        if (datas.principais.inControl)
        {
            rg2d.MovePosition(new Vector2((Input.GetAxis("Horizontal") * datas.principais.speed * Time.deltaTime) + rg2d.position.x, (Input.GetAxis("Vertical") * datas.principais.speed * Time.deltaTime) + rg2d.position.y));

            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
                anim.SetBool("walk", false);
            else
                anim.SetBool("walk", true);

            if (!inAtack)
            {
                if (Input.GetAxis("Vertical") != 0)
                {
                    if (datas.principais.facedRight == false)
                        if (SR.flipX == true)
                            SR.flipX = true;
                    if (datas.principais.facedRight == true)
                        if (SR.flipX == false)
                            SR.flipX = false;
                }

                if (Input.GetAxis("Horizontal") > 0)
                {
                    datas.principais.facedRight = true;
                    SR.flipX = false;
                }

                if (Input.GetAxis("Horizontal") < 0)
                {
                    datas.principais.facedRight = false;
                    SR.flipX = true;
                }
            }


            if (Input.GetButtonDown("Fire1") && GetComponent<Datas>().principais.stamina <= 0 && datas.combatStats.atack)
            {
                Atack();
                GetComponent<Datas>().principais.stamina = 0.5f;
            }
        }

        LifeManager();
    }

    void LifeManager()
    {
        Transform Barra = transform.Find("LifeBar").transform.Find("Barra");
        Barra.localScale = new Vector2(datas.principais.health / datas.principais.maxHealth, Barra.localScale.y);
        if (datas.principais.health <= 0)
            Barra.localScale = new Vector2(0, Barra.localScale.y);
        if (datas.principais.health >= datas.principais.maxHealth)
            Barra.localScale = new Vector2(1, Barra.localScale.y);

        Transform Stamina = transform.Find("Stamina");
        Stamina.localScale = new Vector2(datas.principais.stamina / datas.principais.maxStamina, Barra.localScale.y);
        if (datas.principais.stamina <= 0)
            Stamina.localScale = new Vector2(0, Barra.localScale.y);
        if (datas.principais.stamina >= datas.principais.maxHealth)
            Stamina.localScale = new Vector2(1, Barra.localScale.y);
    }


    void Atack()
    {
        anim.SetBool("atack", true);
        inAtack = true;
        datas.principais.inControl = false;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (worldMousePos.x > transform.position.x)
            SR.flipX = false;
        else
            SR.flipX = true;
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        GameObject bullet = (GameObject)Instantiate(
                                        magePrefab,
                                        transform.position + (Vector3)(direction * 0.5f),
                                        Quaternion.identity);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<CapsuleCollider2D>());
        yield return new WaitForSeconds(0.3f);
        Destroy(bullet, 0.8f);
        anim.SetBool("atack", false);
        inAtack = false;
        yield return new WaitForSeconds(0.3f);
        datas.principais.inControl = true;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
        bullet.GetComponent<BulletController>().available = true;
    }
}
