using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static int MAX_JUMPS = 2;

    private Rigidbody rb;
    private float moveX;
    private float moveZ;
    
    //Jumps
    private float moveY;

    public float moveSpeed = 0;

    //private bool isGrounded = true;


    //Double Jump
    private int jumpsLeft = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue mv)
    {
        Vector2 moveVec = mv.Get<Vector2>();

        moveX = moveVec.x;
        moveZ = moveVec.y;
    }

    void OnJump(InputValue val)
    {
        if (jumpsLeft > 0)
        {
            moveY = 10;
            jumpsLeft--;
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(moveX, 0.0f, moveZ) * moveSpeed);
        if (moveY > 0)
        {
            rb.AddForce(new Vector3(0.0f, moveY, 0.0f) * moveSpeed);
            moveY -= moveY / 3f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
            jumpsLeft = MAX_JUMPS;
        }
    }

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        //isGrounded = false;
    //        //Debug.Log("Ball is in the air!");
    //    }
    //}
}
