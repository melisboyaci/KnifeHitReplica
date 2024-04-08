using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float speed = 100f;

    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
