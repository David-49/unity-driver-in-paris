using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Color explosionColor = Color.red; // Color to change to when the explosion is triggered
    // private bool hasExploded = false;

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!hasExploded && collision.collider.CompareTag("Plane"))
    //     {
    //         hasExploded = true;
    //         TriggerExplosion(collision.contacts[0].point);
    //         ChangeColor();
    //     }
    // }

    public void TriggerExplosion(Vector3 position)
    {
        GameObject explosionInstance = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosionInstance.SetActive(true);
        Destroy(explosionInstance, 5f); // Adjust the time according to your explosion's duration
    }

    void ChangeColor()
    {
        // Change the color of the sphere
        GetComponent<Renderer>().material.color = explosionColor;

        // Find the plane object and change its color
        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        if (plane != null && plane.GetComponent<Renderer>() != null)
        {
            plane.GetComponent<Renderer>().material.color = explosionColor;
        }
    }
}
