using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{

    [SerializeField] private GameObject seeThroughSphere;
    private GameObject instance;
    private bool instantiateSphere = true;
    

    void OnMouseDown()
    {
        if (!instantiateSphere)
        {
            Destroy(instance);
            instantiateSphere = true;
            return;
        }
        instance = Instantiate(seeThroughSphere, this.transform);
        instantiateSphere = false;
    }

}
