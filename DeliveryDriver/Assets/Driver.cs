using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float verticalValue = Input.GetAxis("Vertical");
        float moveAmount = verticalValue * moveSpeed * Time.deltaTime;
        
        if(verticalValue > 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
        else if (verticalValue < 0)
        {
            transform.Rotate(0, 0, steerAmount);
        }
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

}
