using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum AtkPlayer
    {
        atk_up,
        atk_down,
        atk_left,
        atk_right
    }

    [Header("Gameobjects Ataque")]
    public GameObject atk_up;
    public GameObject atk_down;
    public GameObject atk_left;
    public GameObject atk_right;

    [Header("Física")]
    public float speed;

    Animator animator;

    [SerializeField]
    int dano;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");

        if (Mathf.Abs(X) > 0.1)
        {
            animator.SetFloat("X", X);
            animator.SetFloat("Y", 0);
        }

        if (Mathf.Abs(Y) > 0.1)
        {
            animator.SetFloat("Y", Y);
            animator.SetFloat("X", 0);
        }

        transform.Translate(new Vector3(X, Y) * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Atk");
        }

        //Esse é o Console.WriteLine
        Debug.Log("X:" + X + "|Y:" + Y);
    }

    
    public void AtivarAtaque(AtkPlayer atk)
    {
        switch (atk)
        {
            case AtkPlayer.atk_up:
                atk_up.SetActive(true);
                break;

            case AtkPlayer.atk_down:
                atk_down.SetActive(true);
                break;

            case AtkPlayer.atk_left:
                atk_left.SetActive(true);
                break;

            case AtkPlayer.atk_right:
                atk_right.SetActive(true);
                break;
        }
    }

    public void DesativarAtaque()
    {
        atk_up.SetActive(false);
        atk_down.SetActive(false);
        atk_left.SetActive(false);
        atk_right.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Inimigo")
        {
            Inimigo inimigo= collision.GetComponent<Inimigo>();
            inimigo.PerderVida(dano);
        }
    }
}
