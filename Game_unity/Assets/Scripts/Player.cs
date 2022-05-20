using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float JumpForceJet;
    private Rigidbody2D Rig;
    private Animator Animacao;

    public bool isJumping;
    public static bool jetPack = false;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()

    {
        // Move();
        // Jump();
    }

    void Move()
    {
        float Movement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Movement > 0f)
        {
            Animacao.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Movement < 0f)
        {
            Animacao.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            Animacao.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if (jetPack == true && GameController.gameoverbool == false)
        {
            if (Input.GetButton("Jump"))
            {
                Animacao.SetBool("Flying", true);
                // Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                //Rig.AddForce(new Vector2(0f, 1.0f), ForceMode2D.Impulse);         ITCH IO

                Rig.AddForce(new Vector2(0f, 0.8f), ForceMode2D.Impulse); // PC BUILD
            }
        }

        else if (Input.GetButtonDown("Jump") && isJumping == false && GameController.gameoverbool == false)
        {
            AudioManager.instance.Play("Jump");
            Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            Animacao.SetBool("Jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 8)
        {
            isJumping = false;
            Animacao.SetBool("Jump", false);
        }

        if (colisao.gameObject.tag == "Spike" || colisao.gameObject.tag == "Saw")
        {
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Rig.gravityScale = 2;
            JumpForce = 5f;
            Speed = 2;
        }

        if (collision.gameObject.tag == "JetPack")
        {
            //   JumpForce = 8;
            //  Speed = 4;
            jetPack = true;
        }

        // if (collision.gameObject.tag == "Water")
        // {
        //      AudioManager.instance.Play("Water");
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Rig.gravityScale = 4;
            JumpForce = 12;
            Speed = 5;
        }
    }
}
