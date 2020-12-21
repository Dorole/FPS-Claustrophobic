using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimer : MonoBehaviour
{
    public float time = 5.0f;

    private void Start()
    {
        Destroy(gameObject, time);
    }

}
