using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItems : MonoBehaviour
{
    private int _degreesRotation = 45;
    void Update()
    {
        transform.Rotate(0, 0, _degreesRotation * Time.deltaTime);
    }
}
