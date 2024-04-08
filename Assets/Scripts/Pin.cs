using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour
{
    public string Tag = "DefaultPin";

    public bool isPinned = false;
    private bool isFirst = true;
    public float speed = 0f;
    public Rigidbody2D rb;
    

    
    void Update()
    {
        if (isFirst)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
                isFirst = false;
            }
        }

        else if (!isPinned)
        {
                 rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Collision detected");
        if (collision.tag == "Rotater" )
        {
            if (tag != Tag)
            {
                Debug.Log("ROTATER");
                transform.SetParent(collision.transform);
                collision.GetComponent<Rotater>().speed += 20f;
                GameManager.Instance.score++;
                
            }
            isPinned = true;
        }

        else if(collision.tag == "Pin")
        {
            Debug.Log("ENDGAME");
            GameManager.Instance.score--;
            GameManager.Instance.EndGame();
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rotater"))
        {
            Debug.Log("ONCOLL");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}
