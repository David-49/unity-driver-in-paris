using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpoints;
    private int currentCheckpointIndex = -1;
    public Transform startPoint;
    public Color inactiveColor = Color.grey;
    public Color activeColor = Color.yellow;
    public Color nextCheckpointColor = Color.green; // Nouvelle couleur pour le prochain checkpoint

    void Start()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.GetComponent<Renderer>().material.color = inactiveColor;
        }

        // Initialise le premier checkpoint avec la couleur "prochain checkpoint"
        if (checkpoints.Length > 0)
        {
            Debug.Log("COULEUR " + checkpoints[0].GetComponent<Renderer>().material.color);
            Debug.Log("ACTIVE COLOR " + activeColor);
            checkpoints[0].GetComponent<Renderer>().material.color = activeColor;
            Debug.Log("AFTER " + checkpoints[0].GetComponent<Renderer>().material.color);
        }
    }

    public void ActivateNextCheckpoint()
    {
        checkpoints[0].GetComponent<Renderer>().material.color = activeColor;
        // if (currentCheckpointIndex >= 0 
        // && currentCheckpointIndex < checkpoints.Length 
        // && checkpoints[currentCheckpointIndex].GetComponent<Renderer>().material.color == nextCheckpointColor
        // )
        // {
        //     checkpoints[currentCheckpointIndex].GetComponent<Renderer>().material.color = activeColor;
        // }

        // currentCheckpointIndex++;

        // // Change la couleur du prochain checkpoint pour l'indiquer comme le prochain objectif
        // if (currentCheckpointIndex < checkpoints.Length)
        // {
        //     checkpoints[currentCheckpointIndex].GetComponent<Renderer>().material.color = nextCheckpointColor;
        // }
    }

    public Transform GetActiveCheckpoint()
    {
        if (currentCheckpointIndex >= 0 && currentCheckpointIndex < checkpoints.Length)
        {
            return checkpoints[currentCheckpointIndex].transform;
        }
        return startPoint;
    }
}


