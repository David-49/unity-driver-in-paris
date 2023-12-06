using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRace : MonoBehaviour
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
            if (playerCar != null && manager.allCheckpointChecked)
            {
                playerCar.StopTakingDamages();
            }
        }
    }
}
