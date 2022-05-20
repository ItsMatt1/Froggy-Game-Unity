using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float moveTime;
    private bool dirRight = true;
    private float Timer;
    private bool once = false;

    // Update is called once per frame
    void Update()
    {
        if (once == false)
        {
            AudioManager.instance.Play("Saw");
            once = true;
        }

        if (GameController.gameoverbool == false)
        {

            if (dirRight)
            {
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * Speed * Time.deltaTime);
            }

            Timer += Time.deltaTime;

            if (Timer >= moveTime)
            {
                AudioManager.instance.StopPlaying("Saw");
                dirRight = !dirRight;
                Timer = 0f;
                AudioManager.instance.Play("Saw");
            }
        }
    }
}
