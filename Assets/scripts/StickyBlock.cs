using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.transform.parent = gameObject.transform;
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            //Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
        }
    }
    
}
