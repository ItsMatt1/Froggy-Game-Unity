using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;
    private TargetJoint2D Target;
    private BoxCollider2D boxColl;


    // Start is called before the first frame update
    void Start()
    {
        Target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {

        if (colisao.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        Target.enabled = false;
        boxColl.isTrigger = true;
    }
}
