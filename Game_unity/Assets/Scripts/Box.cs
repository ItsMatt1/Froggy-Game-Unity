using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float jumpForce;
    public bool isUp;

    private int Counter = 0;

    public Animator anim;

    private int Score = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isUp)
            {
                Counter++;
                anim.SetTrigger("Hit");

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                if (Counter == 3)
                {
                    AudioManager.instance.Play("Strawberry");
                    GameController.instance.totalScore += Score;
                    GameController.instance.UpdateScoreText();

                    Destroy(transform.parent.gameObject, 0.05f);
                }
                AudioManager.instance.Play("Jump");
            }
            else
            {
                Counter++;
                anim.SetTrigger("Hit");

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);

                if (Counter == 3)
                {
                    AudioManager.instance.Play("Strawberry");
                    GameController.instance.totalScore += Score;
                    GameController.instance.UpdateScoreText();

                    Destroy(transform.parent.gameObject, 0.05f);
                }
                AudioManager.instance.Play("Jump");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Hit");
        }
    }
}
