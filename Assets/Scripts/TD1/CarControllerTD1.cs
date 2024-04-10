using UnityEngine;

public class CarControllerTD1 : MonoBehaviour
{
    public Rigidbody rg;
    public float acceleration = 50f; // Vitesse d'accélération
    public float maxSpeed = 150f; // Vitesse maximale
    public float turnSpeed = 200f; // Vitesse de rotation

    private bool isFrozen = false;

    private float inputX;
    private float inputY;

    void Update()
    {
        if (isFrozen) return;

        // Récupère les inputs du joueur
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (isFrozen) return;

        // Applique l'accélération en direction de l'avant de la voiture
        Vector3 accelerationDirection = transform.forward * inputY;
        if (rg.velocity.magnitude < maxSpeed)
        {
            rg.AddForce(accelerationDirection * acceleration, ForceMode.Acceleration);
        }

        // Gère la rotation
        if (inputX != 0)
        {
            float rotation = inputX * turnSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, rotation, 0);
        }

        // Ajuste la vélocité de la voiture pour qu'elle suive la nouvelle direction après le virage
        if (inputY != 0) // Si le joueur accélère ou recule
        {
            rg.velocity = Vector3.Lerp(rg.velocity, transform.forward * rg.velocity.magnitude, Time.fixedDeltaTime * turnSpeed * Mathf.Abs(inputX));
        }
    }

    public void Freeze()
    {
        isFrozen = true;
        rg.velocity = Vector3.zero; // Arrête tout mouvement
        rg.angularVelocity = Vector3.zero; // Arrête toute rotation
    }

    public void UnfreezePlayer()
    {
        isFrozen = false;
    }
}