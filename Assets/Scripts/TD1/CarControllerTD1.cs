using UnityEngine;

public class CarControllerTD1 : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;

    private bool isFrozen = false;

    private float inputX;
    private float inputY;
    void Update() // Get keyboard inputs
    {
        if (isFrozen) return;
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
    }
    
    void FixedUpdate() // Apply physics here
    {
        // Accelerate
        float speed = inputY > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (inputY == 0) speed = 0;
        rg.AddForce(this.transform.forward * speed, ForceMode.Acceleration);
        // Steer
        float rotation = inputX * steerSpeed * Time.fixedDeltaTime;
        if (inputY == 0) rotation = 0;
        transform.Rotate(0, rotation, 0, Space.World);
    }

    public void Freeze()
    {
        isFrozen = true;
        rg.velocity = Vector3.zero; // Stop all movement
    }

    public void UnfreezePlayer()
    {
        isFrozen = false;
    }
}
