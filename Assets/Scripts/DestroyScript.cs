using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public float DestroyTime = 3.0f;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);       
    }


}
