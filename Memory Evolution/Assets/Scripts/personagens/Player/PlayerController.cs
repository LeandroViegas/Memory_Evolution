using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2d;
    Animator anim;
    public GameObject magePrefab;
    public float bulletVelocity = 20f;
    public Datas dados;
    public float atackRemaining;

    void Start()
    {
        dados = GetComponent<Datas>();
        rg2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Datas>().principais.stamina > 0)
            GetComponent<Datas>().principais.stamina -= Time.deltaTime;
        if(dados.combatStats.damageRemaining > 0f)
            dados.combatStats.damageRemaining -= Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
        if (dados.principais.health <= 0)
            Destroy(gameObject);

        rg2d.MovePosition(new Vector2((Input.GetAxis("Horizontal") * dados.principais.speed * Time.deltaTime) + rg2d.position.x, (Input.GetAxis("Vertical") * dados.principais.speed * Time.deltaTime) + rg2d.position.y));

        SpriteRenderer SR = GetComponent<SpriteRenderer>();

        if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            anim.SetBool("walk", false);
        else
            anim.SetBool("walk", true);

        if (Input.GetAxis("Vertical") != 0)
        {
            if (dados.principais.facedRight == false)
                if (SR.flipX == true)
                    SR.flipX = true;
            if (dados.principais.facedRight == true)
                if (SR.flipX == false)
                    SR.flipX = false;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            dados.principais.facedRight = true;
            SR.flipX = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            dados.principais.facedRight = false;
            SR.flipX = true;
        }

        if (Input.GetButtonDown("Fire1") && GetComponent<Datas>().principais.stamina <= 0)
        {
            Atack();
            GetComponent<Datas>().principais.stamina = 0.5f;
        }
           
        LifeManager();
    }

    void LifeManager()
    {
        Transform Barra = transform.Find("LifeBar").transform.Find("Barra");
        Barra.localScale = new Vector2(dados.principais.health / dados.principais.maxHealth, Barra.localScale.y);
        if (dados.principais.health <= 0)
            Barra.localScale = new Vector2(0, Barra.localScale.y);
        if(dados.principais.health >= dados.principais.maxHealth)
            Barra.localScale = new Vector2(1, Barra.localScale.y);

        Transform Stamina = transform.Find("Stamina");
        Stamina.localScale = new Vector2(dados.principais.stamina / dados.principais.maxStamina, Barra.localScale.y);
        if (dados.principais.stamina <= 0)
            Stamina.localScale = new Vector2(0, Barra.localScale.y);
        if (dados.principais.stamina >= dados.principais.maxHealth)
            Stamina.localScale = new Vector2(1, Barra.localScale.y);
    }


    void Atack()
    {
        anim.SetBool("atack", true);
        StartCoroutine(Delay(10/10));   
    }

    IEnumerator Delay(int time)
    {
        yield return new WaitForSeconds(0);
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();

        if(magePrefab != null)
        {
            GameObject bullet = (GameObject)Instantiate(
                                            magePrefab,
                                            transform.position + (Vector3)(direction * 0.5f),
                                            Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<CapsuleCollider2D>());
            Destroy(bullet, 1);
        }
        anim.SetBool("atack", false);
    }
}
