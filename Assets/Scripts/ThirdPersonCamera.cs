using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0,2,-5);
    [SerializeField] float rotationSpeed = 200f;

    
    private float currentX = 0f;
    private float currentY = 0f;
    private float minY = -20f, maxY = 50f;

    void LateUpdate()
    {
        
        currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        
        currentY = Mathf.Clamp(currentY, minY, maxY);

        
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
        transform.LookAt(target.position);
    }
}
