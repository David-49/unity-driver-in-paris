using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager manager;

    void Start()
    {
        manager = FindObjectOfType<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Car"))
        {
            Car playerCar = collider.gameObject.GetComponent<Car>();
            if (playerCar != null)
            {
                if (GetComponent<Renderer>().material.color == manager.nextCheckpointColor)
                {
                    playerCar.ResetHealth();
                    manager.ActivateNextCheckpoint();
                }
            }
        }
    }
}
