using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class playerMov : MonoBehaviour
{
   // public TMP_Text texto;
    float x;
    SpriteRenderer spr;
    Rigidbody2D rigid;
    bool jumping;
    private int pontos;
    Animator anm;
    public float speed;
    public float fJump;

    void Start()
    {
        pontos = 10;
        jumping = false;
        x = 0.01f;
        spr = gameObject.GetComponent<SpriteRenderer>();
        anm = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent < Rigidbody2D>();
        //texto.SetText("Pontos: " + pontos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spr.flipX = false;
            x = 0.01f;
            anm.SetBool("andando", true);
        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spr.flipX = true;
            x = -0.01f;
            anm.SetBool("andando", true);
        }

        else
        {
            x = 0;
            anm.SetBool("andando", false);
        }

        if (Input.GetAxisRaw("Jump") > 0 && !jumping)
        {
            rigid.AddForce(new Vector2(0, fJump), ForceMode2D.Impulse);
            jumping = true;
        }
        
        Vector3 pNova = new Vector3(x*speed*Time.deltaTime, 0.0f);
        gameObject.transform.position += pNova;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.transform.CompareTag("moeda") || collision.transform.CompareTag("bicho"));
        //{
            //collision.transform.localScale = new Vector3(2, 2, 0);
            //pontos++;
        //}

        if (collision.gameObject.name == "box")
        {
            Debug.Log("enter");
        }

        if (collision.transform.CompareTag("goomba"))
        {
            pontos--;
            //texto.SetText("Pontos: " + pontos);
            if (spr.flipX==true)
            {
                rigid.AddForce(new Vector2(2, 0), ForceMode2D.Force);
            } else {
                rigid.AddForce(new Vector2(-2, 0), ForceMode2D.Force);
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.name == "box"){
            Debug.Log("stay");
    }
    }

        private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.name == "box"){
            Debug.Log("exit");
    }
        }
}
