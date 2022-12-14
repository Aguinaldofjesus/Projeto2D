using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public float speed;
    public float TempoDano;

    protected float contadorDano;

    protected PlayerController player;
    protected Animator animator;
    protected Collider2D collider2D;

    protected bool morto = false;
    protected bool LevouDano = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void PerderVida(int dano)
    {
        vida -= dano;
        LevouDano = true;
        animator.SetBool("Dano", true);
        if (vida <= 0)
        {
            morto = true;
            collider2D.enabled = false;
            animator.SetTrigger("Morte");
        }
    }



    //Conta Dano Levado
    protected void ContaDano()
    {
        if (LevouDano == true)
        {
            contadorDano += Time.deltaTime;
            if (contadorDano >= TempoDano)
            {
                LevouDano = false;
                contadorDano = 0;
                animator.SetBool("Dano", false);
            }
        }

    }


    //Destroi o Objeto
    public void Destruir()
    {
        Destroy(gameObject);
    }



}
