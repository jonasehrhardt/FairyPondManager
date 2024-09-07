using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{   

    [field: Header("PondSound")]
    [field: SerializeField] public EventReference pondSound { get; private set; }

    public static FmodEvents instance { get; private set; }

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.LogError("Found more than one FmodEvents instance!");
        }

        instance = this;
    }
}
