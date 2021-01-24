using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is only used when the mole is under. When the mole is under, it will be destroyed
/// </summary>
public class Destroy : MonoBehaviour
{
   
    private float destroyTime = 1.2f;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
