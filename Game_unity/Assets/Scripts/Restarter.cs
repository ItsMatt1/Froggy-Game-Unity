using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    public string levelName;

    public void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            GameController.instance.RestartGame(levelName);
            GameController.instance.LosePoints();
        }
    }
}
