using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Phases : ScriptableObject
{
    public float timeThreshold;

    public float[] multipliers;
    public float[] probabilities;
    public GameObject[] obstcle;



}
