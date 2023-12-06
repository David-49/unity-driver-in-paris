using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Cible que la caméra doit suivre
    public Vector3 offset;   // Décalage de la position de la caméra par rapport à la cible

    void LateUpdate()
    {
        // Met à jour la position de la caméra pour qu'elle suive la cible avec le décalage spécifié
        transform.position = target.position + offset;

        // Optionnel : Faire en sorte que la caméra regarde toujours vers la cible
        transform.LookAt(target);
    }
}
