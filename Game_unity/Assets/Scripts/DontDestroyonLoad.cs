using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameController;

public class DontDestroyonLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Momentum");

        DontDestroyOnLoad(gameObject);
    }

}
