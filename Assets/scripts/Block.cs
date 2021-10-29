using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D blockRigidBody;
    Vector3 oldPlayerPosition;
    bool collided = false;
    [SerializeField]
    float playerThrust = 200f;

    // Start is called before the first frame update
    void Start()
    {
        blockRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /***
     *  FindObjectByTag()
        sla position op in collision
        set collided bool
        in fixedupdate check position 
	        bereken verschil
	        addforce op blok
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        oldPlayerPosition = player.transform.position;
        collided = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collided = false;
    }

    private void FixedUpdate()
    {
        if (collided)
        {
            //Debug.Log("FIXEDUPDATE COLLIDED");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 newPlayerPosition = player.transform.position;
            Vector3 difference = newPlayerPosition - oldPlayerPosition;
            blockRigidBody.AddForce(difference * playerThrust);
            oldPlayerPosition = newPlayerPosition;
        }
    }
}
