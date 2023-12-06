using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ajout pour utiliser les éléments UI

public class FinishRace : MonoBehaviour
{
    private CheckpointManager manager;
    public GameObject victoryMessage; // Référence à l'élément UI du message de victoire

    void Start()
    {
        manager = FindObjectOfType<CheckpointManager>();
        // Assurez-vous que le message de victoire est désactivé au début
        victoryMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Car"))
        {
            Car playerCar = collider.gameObject.GetComponent<Car>();
            if (playerCar != null && manager.allCheckpointChecked)
            {
                playerCar.StopTakingDamages();
                // Afficher le message de victoire
                victoryMessage.SetActive(true);
            }
        }
    }
}
