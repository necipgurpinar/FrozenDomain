using UnityEngine;

public class Test : MonoBehaviour
{
   [SerializeField] float movementSpeed;
   private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        movementInput();
    }


    void movementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontal,0,vertical).normalized;
        rb.linearVelocity = movementDirection * movementSpeed + new Vector3(0,rb.linearVelocity.y,0);

        if(movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }
    }
}
