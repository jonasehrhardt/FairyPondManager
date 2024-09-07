using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{   

    [field: Header("PondSound")]
    [field: SerializeField] public EventReference pondSound { get; private set; }

    [field: Header("Footsteps")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }

    [field: Header("ShroomPondParty")]
    [field: SerializeField] public EventReference partyMusic { get; private set; }

    [field: Header("ShroomPondBasic")]
    [field: SerializeField] public EventReference basicMusic { get; private set; }

    [field: Header("FrogLeaf")]
    [field: SerializeField] public EventReference frogLeaf { get; private set; }

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
