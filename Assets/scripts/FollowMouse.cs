using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    //HERSCHRIJVEN NAAR FOLLOWPLAYER SCRIPT
    // variables
    private Vector3 mousePosition;
    [SerializeField]
    public float moveSpeed = 0.1f;
    float inertiacounter = 0f;

    public bool goingLeft = false;
    public bool goingRight = false;
    //public float playerSpeed;

    public float playerOldX;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerOldX = player.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);*/
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //transform.position = Vector2.Lerp(transform.position, player.transform.position, moveSpeed);
        //transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, transform.localPosition.z, Time.deltaTime * 1));
        //Rigidbody2D playerRigidBody = player.GetComponent<Rigidbody2D>();
        
        if (playerOldX != player.transform.position.x)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.transform.position.x, Time.deltaTime * moveSpeed), transform.position.y, transform.position.z);
        }
        playerOldX = player.transform.position.x;
        /*Vector3 newPosition = mousePosition - transform.position;
        newPosition.z = 0;

        

        float speed = moveSpeed * newPosition.x;
        transform.Translate(newPosition);*/
        /*if(inertiacounter > 0)
        {
            //blijf
            inertiacounter--;
        }
        else
        {
            if (newPosition.x < 0 && !goingRight && !goingLeft)
            {
                inertiacounter = 300f;
                goingRight = false;
                goingLeft = false;
            }
            else if (newPosition.x > 0 && !goingRight && !goingLeft)
            {
                inertiacounter = 300f;
                goingLeft = false;
                goingRight = true;
            }
            else
            {
                goingLeft = false;
                goingRight = false;
            }
        }
        Move(speed);*/
    }

    void Move(float speed)
    {
        if (goingRight)
        {
            transform.position += Vector3.right * 100;
            //transform.Translate(movement);
        }
        else if (goingLeft)
        {
            transform.position += Vector3.left * 100;
            //transform.Translate(movement);
        }
    }
}
