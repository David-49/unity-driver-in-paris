using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    // Définition des constantes pour les axes de contrôle
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    // Variables pour les entrées utilisateur
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    // Paramètres modifiables dans l'éditeur Unity
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    // [SerializeField] private AudioSource CarEngine;
    // [SerializeField] private AudioSource CarDrift;

    // Méthode appelée à chaque frame fixe
    private void FixedUpdate()
    {
        // Obtenir les entrées utilisateur
        GetInput();

        // Gérer la motorisation
        HandleMotor();

        // Gérer la direction
        HandleSteering();

        // Mettre à jour la rotation des roues
        UpdateWheels();
    }

    // Méthode pour obtenir les entrées utilisateur
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    // Méthode pour gérer la motorisation
    private void HandleMotor()
    {
        // Appliquer la force motrice aux roues avant
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        // Démarrer le son du moteur (ne fonctionne pas)
        // CarEngine.play();

        // Définir la force de freinage actuelle en fonction de la décélération
        currentbreakForce = isBreaking ? breakForce : 0f;

        // Appliquer la force de freinage
        ApplyBreaking();
    }

    // Méthode pour appliquer la force de freinage
    private void ApplyBreaking()
    {
        // Appliquer la force de freinage à toutes les roues
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;

        // Jouer le son de dérapage
        // Ne fonctionne pas
        // CarDrift.Play(); // Jouer le son de dérapage
    }

    // Méthode pour gérer la direction
    private void HandleSteering()
    {
        // Calculer l'angle de braquage actuel
        currentSteerAngle = maxSteerAngle * horizontalInput;

        // Appliquer l'angle de braquage aux roues avant
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    // Méthode pour mettre à jour la rotation des roues
    private void UpdateWheels()
    {
        // Mettre à jour la rotation de chaque roue
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    // Méthode pour mettre à jour la rotation d'une seule roue
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        // Obtenir la position et la rotation de la roue dans le monde
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);

        // Mettre à jour la rotation et la position de la roue dans l'espace du monde
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}