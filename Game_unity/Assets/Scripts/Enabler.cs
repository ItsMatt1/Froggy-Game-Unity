using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    private SpriteRenderer Spr;
    private BoxCollider2D Col;

    void Start()
    {
        Spr = GetComponent<SpriteRenderer>();
        Col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Player.jetPack == true)
        {
            Spr.enabled = true;
            Col.enabled = true;
        }
    }
}
