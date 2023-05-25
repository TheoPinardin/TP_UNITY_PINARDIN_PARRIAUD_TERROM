using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSplitting : MonoBehaviour
{
    public GameObject Back;
    public GameObject Exhaust;
    public GameObject Core;
    public GameObject Rotor;
    public bool SplitEngi;
    public bool isSplitting;
    public Vector3 targetPosB;
    public Vector3 targetPosC;
    public Vector3 targetPosE;
    public Vector3 targetPosR;

    public Vector3 initialPosB;
    public Vector3 initialPosC;
    public Vector3 initialPosE;
    public Vector3 initialPosR;


    public float moveDistance = 0.1f; // Distance de déplacement des objets
    public float duration= 0.5f; // Durée du mouvement des objets

    private float elapsedTime = 0.0f; // Timer pour suivre la progression du mouvement

    private void Start()
    {
        ScrewManager screwManager = FindObjectOfType<ScrewManager>();

        if (screwManager != null)
        {
            screwManager.m_MyEvent.AddListener(StartEngineSplitting);
        }   

        initialPosB = Back.transform.position;
        initialPosE = Exhaust.transform.position;
        initialPosC = Core.transform.position;
        initialPosR = Rotor.transform.position;

        targetPosB = initialPosB + new Vector3(-1f, 0f, 0f);
        targetPosE = initialPosE + new Vector3(-0.5f, 0f, 0f);
        targetPosC = initialPosC + new Vector3(0.8f, 0f, 0f);
        targetPosR = initialPosR + new Vector3(2f, 0f, 0f);
    }
private void Update()
    {
        if (isSplitting)
        {
            // Mettez à jour le temps écoulé
            elapsedTime += Time.deltaTime;

            // Calculez le facteur d'interpolation en utilisant la fonction d'interpolation souhaitée (ease-in/out)
            float t = SmoothStep(0f, 1f, elapsedTime / duration);

            // Effectuez la séparation progressive des parties du moteur en utilisant l'interpolation lerp
            Back.transform.position = Vector3.Lerp(initialPosB, targetPosB, t);
            Exhaust.transform.position = Vector3.Lerp(initialPosE, targetPosE, t);
            Core.transform.position = Vector3.Lerp(initialPosC, targetPosC, t);
            Rotor.transform.position = Vector3.Lerp(initialPosR, targetPosR, t);

            if (t >= 1f)
            {
                // La séparation est terminée, désactivez l'écoute de l'événement
                ScrewManager screwManager = FindObjectOfType<ScrewManager>();

                if (screwManager != null)
                {
                    screwManager.m_MyEvent.RemoveListener(StartEngineSplitting);
                }

                isSplitting = false;
            }
        }
    }

    private void StartEngineSplitting()
    {
        isSplitting = true;
    }

    private float SmoothStep(float edge0, float edge1, float x)
    {
        x = Mathf.Clamp01(x);
        x = x * x * (3f - 2f * x);
        return Mathf.Lerp(edge0, edge1, x);
    }

    public void isSplittingBool(bool a)
    {
        isSplitting = a;
    }
}