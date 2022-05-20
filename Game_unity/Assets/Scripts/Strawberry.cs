using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    private SpriteRenderer Spr;
    private CircleCollider2D CC2D;

    public GameObject Collected;

    public int Score;

    private int totalScore;

    private int total_Score;

    void Start()
    {
        Spr = GetComponent<SpriteRenderer>();
        CC2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("Strawberry");
            //FindObjectOfType<AudioManager>().Play("Strawberry");

            Spr.enabled = false;
            CC2D.enabled = false;

            // desabilitou colissoes.

            Collected.SetActive(true);

            // ativou a animação de coletar.

            GameController.instance.totalScore += Score;

            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);

            // destruiu o objeto.
        }
    }
}
