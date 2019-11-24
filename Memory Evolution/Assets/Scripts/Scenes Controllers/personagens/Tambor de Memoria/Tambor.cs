using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambor : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    bool explosion = false;
    float color;
    bool add;
    public float timer;
    GameObject Enemy = null;

    public GameObject esplosao; 
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (explosion)
        {
            timer += Time.deltaTime;
            if (color >= 255)
                add = false;
            if (color <= 0)
                add = true;
            if (add)
                color += 255 * timer * 40 * Time.deltaTime;
            else
                color -= 255 * timer * 40 * Time.deltaTime;
            spriteRenderer.color = new Color(ColorCal(255f), ColorCal(color), ColorCal(color));
            if (timer >= 1.5f)
            {
                if (Enemy != null)
                    Enemy.GetComponent<Actions>().Damage(40);
                Explosion();
            }
                
        }
    }

    float ColorCal(float cor)
    {
        return cor / 255;
    }

    void Explosion()
    {
        GameObject esplosao1 = Instantiate(esplosao,transform.position,transform.rotation);
        Destroy(gameObject);
        Destroy(esplosao1, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
            {
                explosion = true;
                Enemy = collision.gameObject;
            }
                
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                Enemy = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                Enemy = null;
    }
}
