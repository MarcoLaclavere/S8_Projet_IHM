using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessController : MonoBehaviour
{
    public Transform target; // Cible que la caméra doit suivre (typiquement votre personnage joueur)
    public Vector3 offset; // Décalage par rapport à la cible
    public float sensitivity = 10f; // Sensibilité de la rotation de la caméra

    private float currentYaw = 0f;


    private float currentPitch = 0f; // Ajout pour le mouvement vertical

    public float pitchMin = -60f; // Limite minimum pour le mouvement vertical
    public float pitchMax = 60f; // Limite maximum pour le mouvement vertical


    void Update()
    {
        // Rotation horizontale
        currentYaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentPitch += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        currentPitch = Mathf.Clamp(currentPitch, pitchMin, pitchMax); 
    }

void LateUpdate()
{
    // Calculer la direction depuis la cible
    Vector3 direction = -target.transform.forward;
    Vector3 desiredCameraPosition = target.position 
        + offset.y * target.transform.up 
        + offset.x * target.transform.right 
        - offset.z * direction;

    RaycastHit hit;
    if (Physics.Raycast(target.position, direction, out hit, offset.z))
    {
        // Si un obstacle est détecté, positionner la caméra près de l'obstacle
        desiredCameraPosition = hit.point;

        // Si la caméra touche le sol, ajuster son angle de tangage
        if (hit.normal == Vector3.up) 
        {
            currentPitch = Mathf.Max(currentPitch, 20f); // Ajuster selon les besoins
        }
    }

    // Appliquer la position et la rotation de la caméra
    transform.position = desiredCameraPosition;
    transform.LookAt(target.position);

    // Appliquer la rotation horizontale et verticale
    transform.RotateAround(target.position, Vector3.up, currentYaw);
    transform.RotateAround(target.position, Vector3.right, currentPitch);
}

}
