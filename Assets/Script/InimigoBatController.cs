using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBatController : Inimigo
{

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
    }


    //Movimentação
   void Movimento()
    {
        if (morto == false && LevouDano == false)
        {

            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }


}
