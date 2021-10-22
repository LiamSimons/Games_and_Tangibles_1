using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // variables
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        Vector3 newPosition = mousePosition - transform.position;
        newPosition.z = 0;
        transform.Translate(newPosition);
    }
}
