using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSlimeController : Inimigo
{
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ContaDano();
        Movimento();
        if (morto == true)
            animator.SetTrigger("Morte");
    }


    //Movimentação
    void Movimento()
    {
        if (morto == false && LevouDano == false)
        {

            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance > 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                animator.SetBool("Andar", true);
            }
            else
            {
                animator.SetBool("Andar", false);
                animator.SetTrigger("Atirar");
            }
        }
    }

    public void Atirar()
    {
        //Instantiate(bulletPrefab,transform.position,Quaternion.identity);

        GameObject GO = Instantiate(bulletPrefab,transform.position, Quaternion.identity);
        BulletController bullet = GO.GetComponent<BulletController>();
        Vector2 vector = player.transform.position - transform.position;
        bullet.SetVelocity(vector.normalized);
    }

}
