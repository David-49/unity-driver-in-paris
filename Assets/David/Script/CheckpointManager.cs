using UnityEngine;
using System.IO; // Add this line


public class CheckpointManager : MonoBehaviour
{
    public GameObject[] checkpoints;
    public GameObject Car;
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
        string folderPath = "Assets/Jessy/Racing_Car_Package/Materials/Color_Variations";
        string[] materialFiles = Directory.GetFiles(folderPath, "*.mat");
        string randomMaterialPath = materialFiles[Random.Range(0, materialFiles.Length)];
        Material randomMaterial = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>(randomMaterialPath);
        currentCheckpointIndex++;

        if (currentCheckpointIndex >= 0 && currentCheckpointIndex < checkpoints.Length)
        {
            randomMaterial.SetColor("_Color", Random.ColorHSV());
            Car.GetComponent<Renderer>().material = randomMaterial;
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


