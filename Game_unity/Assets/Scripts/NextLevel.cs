using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public string levelName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelName);
            AudioManager.instance.StopPlaying("Saw");
            AudioManager.instance.StopPlaying("Air");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelName);
            AudioManager.instance.StopPlaying("Saw");
            AudioManager.instance.StopPlaying("Air");
        }
    }
}
