using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovment : MonoBehaviour
{
  [SerializeField] float _movementSpeed;
  
  private Rigidbody rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody>();
    
  }

  void FixedUpdate()
  {
    MovePlayer();
  }

  void MovePlayer()
  {
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveZ = Input.GetAxisRaw("Vertical");

    Vector3 _moveDirection = new Vector3(moveX, 0, moveZ).normalized;
    rb.linearVelocity = _moveDirection * _movementSpeed + new Vector3(0,rb.linearVelocity.y,0);

    if (_moveDirection != Vector3.zero)
    {
      transform.forward = _moveDirection;
    }

    

  }

}
