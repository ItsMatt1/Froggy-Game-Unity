using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_sfx : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("Water");

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.StopPlaying("Water");
        }
    }
}
