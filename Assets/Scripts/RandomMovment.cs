using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public Vector3 minBounds;
    public Vector3 maxBounds;

    private Vector3 targetPosition;

    void Start()
    {
        // Définir une position aléatoire initiale
        SetRandomTargetPosition();
    }

    void Update()
    {

        transform.LookAt(targetPosition);
        // Se déplacer vers la position cible
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Vérifier si le PNJ est proche de la position cible
        if (Vector3.Distance(transform.position, targetPosition) < 2f)
        {
            // Si proche, définir une nouvelle position cible aléatoire
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Générer une position aléatoire à l'intérieur des limites définies
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }
}
