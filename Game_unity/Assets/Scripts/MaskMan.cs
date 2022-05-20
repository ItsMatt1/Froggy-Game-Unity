using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMan : MonoBehaviour
{
    private Rigidbody2D Rig;
    private Animator Anim;

    public float Speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask Layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    private float height;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rig.velocity = new Vector2(Speed, Rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, Layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            rightCol.transform.localScale = new Vector2(rightCol.localScale.x * -1f, rightCol.localScale.y);
            leftCol.transform.localScale = new Vector2(leftCol.localScale.x * -1f, leftCol.localScale.y);
            Speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            height = collision.contacts[0].point.y - headPoint.position.y;

            if (height > 0)
            {
                AudioManager.instance.Play("Maskman");
                AudioManager.instance.Play("Jump");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                Speed = 0;
                Anim.SetTrigger("Hit");

                Rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
            }
            else
            {
                GameController.instance.GameOver();
            }
        }
    }
}
