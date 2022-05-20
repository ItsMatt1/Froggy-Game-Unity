using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public float Speed;
    public float moveTime;

    //private bool dirRight = true;
    private float Timer;

    /*
        void Update()
        {
            if (dirRight)
            {
                transform.Translate(Vector2.up * Speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * Speed * Time.deltaTime);
            }

            Timer += Time.deltaTime;

            if (Timer >= moveTime)
            {
                dirRight = !dirRight;
                Timer = 0f;
            }
        }

        */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
