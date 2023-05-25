using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float rotationSpeed = 30;
    public float moveSpeed = 2.0f; // Vitesse de déplacement de la caméra
    public float maxYPosition = 2.0f; // Position Y maximale
    public float minYPosition = -2.0f; // Position Y minimale
    public Vector3 rotationAxis = Vector3.up;


    // Update is called once per frame
    void Update()
    {

        float HorizontalInput = Input.GetAxis("Horizontal");
      
        float currentRotationSpeed = rotationSpeed * Time.deltaTime * HorizontalInput;

        transform.RotateAround(rotationAxis, Vector3.up, rotationSpeed * HorizontalInput * Time.deltaTime);


        float verticalInput = Input.GetAxis("Vertical"); // Récupérer l'input vertical

        // Calculer le déplacement vertical
        float verticalMovement = verticalInput * moveSpeed * Time.deltaTime;


        float newYPosition = transform.position.y + verticalMovement;

        newYPosition = Mathf.Clamp(newYPosition, minYPosition, maxYPosition);

        Vector3 newPosition = new Vector3(transform.position.x, newYPosition, transform.position.z);

        // Appliquer le déplacement à la position de la caméra
        transform.position = newPosition;
        transform.LookAt(Vector3.zero);



    }
}
