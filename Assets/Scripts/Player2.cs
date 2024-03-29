using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;
    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Raw value, doesn't matter how hard player presses the button
        float directionY = Input.GetAxisRaw("Vertical2");
        racketDirection = new Vector2(0, directionY).normalized;
    }

    //Called once per physics frame
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}