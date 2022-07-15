using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float vel = 5.0f;  
    public float correrVel = 8.0f; 
    public float fuerzaSalto = 600f; 

    public LayerMask capaSuelo;
    public Transform checkSuelo;

    bool enSuelo;
    bool dobleSalto;

    Rigidbody2D rb;
    Vector3 escalaPric;


         //Movimiento

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        escalaPric = transform.localScale;
    }

         
         //Correr

    private void Update()
    {
        float h;
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            h = Input.GetAxis("Horizontal") * correrVel;
        }
        else
        {
            h = Input.GetAxis("Horizontal") * vel;
        }

          
         //Salto

        rb.velocity = new Vector2(h, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W))
        {

            if(enSuelo) 
            { 
            rb.AddForce(Vector2.up * fuerzaSalto);
            }else if (dobleSalto) 
            {
            rb.velocity = Vector2.zero;    
            rb.AddForce(Vector2.up * fuerzaSalto);
            dobleSalto = false;
            }
        }


        if(rb.velocity.x > 0)
        {
            transform.localScale = escalaPric;
        }else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-escalaPric.x, escalaPric.y, escalaPric.z);
        }


         //Doble Salto

        if (enSuelo)
            dobleSalto = true;

    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(checkSuelo.position, 0.1f, capaSuelo);
    }

         //Union con PlataformaMovil

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlataformaMovil")
        {
           transform.parent = collision.transform; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlataformaMovil")
        {
           transform.parent = null; 
        }
    }



}
