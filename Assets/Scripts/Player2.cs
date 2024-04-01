using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;
    private Rigidbody2D rb;
    private Vector2 racketDirection;

    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //Raw value, doesn't matter how hard player presses the button
        float directionY = Input.GetAxisRaw("Vertical2");
        racketDirection = new Vector2(0, directionY).normalized;

        if (currentSceneIndex == 3)
        {
            float dirX = Input.GetAxisRaw("Horizontal2");
            float dirY = Input.GetAxisRaw("Vertical2");

            if (rb.transform.position.x <= 0 && dirX == -1)
            {
                Vector2 currentPos2 = rb.transform.position;
                rb.transform.position = new Vector2(0, currentPos2.y);
                racketDirection = new Vector2(0, dirY).normalized;
            }

            else
            {
                racketDirection = new Vector2(dirX, dirY).normalized;
            }
        }
    }

    //Called once per physics frame
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}