using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSplitting : MonoBehaviour
{
    public GameObject Back;
    public GameObject Exhaust;
    public GameObject Core;
    public GameObject Rotor;

    public float moveDistance = 1.0f; // Distance de déplacement des objets
    public float moveDuration = 2.0f; // Durée du mouvement des objets

    private float moveTimer = 0.0f; // Timer pour suivre la progression du mouvement

    private void Update()
    {
        // Vérifier si le mouvement est terminé
        if (moveTimer >= moveDuration)
            return;

        // Calculer la progression du mouvement
        moveTimer += Time.deltaTime;
        float t = Mathf.SmoothStep(0.0f, 1.0f, moveTimer / moveDuration);

        // Appliquer le mouvement aux objets
        MoveObject(Back, t);
        MoveObject(Exhaust, t);
        MoveObject(Core, t);
        MoveObject(Rotor, t);
    }

    private void MoveObject(GameObject obj, float t)
    {
        // Calculer la position cible en fonction de la distance et de la progression du mouvement
        float targetX = obj.transform.position.x + moveDistance;
        Vector3 targetPosition = new Vector3(targetX, obj.transform.position.y, obj.transform.position.z);

        // Interpoler la position actuelle vers la position cible
        obj.transform.position = Vector3.Lerp(obj.transform.position, targetPosition, t);
    }
}