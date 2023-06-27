using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x;
    public Rigidbody2D rb;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "PinkSlime")
        {
            x = Input.GetAxisRaw("PinkHorizontal");
        }
        else if (this.name == "PurpleSlime")
        {
            x = Input.GetAxisRaw("PurpleHorizontal");
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }
}
