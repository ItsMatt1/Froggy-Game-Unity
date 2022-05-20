using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    void Start()
    {
        if (GameController.gameoverbool == false)
        {
            AudioManager.instance.Play("Air");
        }
    }
}
