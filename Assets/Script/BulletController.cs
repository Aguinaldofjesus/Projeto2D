using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVelocity(Vector2 vector)
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = vector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
