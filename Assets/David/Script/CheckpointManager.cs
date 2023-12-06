using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpoints;
    private int currentCheckpointIndex = -1;
    public Transform startPoint;
    public Color inactiveColor;
    public Color activeColor;
    public Color nextCheckpointColor;
    public bool allCheckpointChecked = false;

    void Start()
    {
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.GetComponent<Renderer>().material.color = inactiveColor;
        }

        if (checkpoints.Length > 0)
        {
            checkpoints[0].GetComponent<Renderer>().material.color = nextCheckpointColor;
        }
    }

    public void ActivateNextCheckpoint()
    {
        currentCheckpointIndex++;

        if (currentCheckpointIndex >= 0 && currentCheckpointIndex < checkpoints.Length)
        {
            checkpoints[currentCheckpointIndex].GetComponent<Renderer>().material.color = activeColor;
        }

        if (currentCheckpointIndex + 1 < checkpoints.Length)
        {
            checkpoints[currentCheckpointIndex + 1].GetComponent<Renderer>().material.color = nextCheckpointColor;
        } else
        {
            allCheckpointChecked = true;
        }
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


