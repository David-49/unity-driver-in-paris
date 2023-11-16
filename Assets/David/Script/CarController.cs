using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Vitesse de déplacement du cube

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Déplacement horizontal
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // Déplacement vertical

        transform.Translate(moveX, 0, moveZ); // Applique le déplacement
    }
}
