using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    [SerializeField] float alturaMax, alturaMin, lateralMax, lateralMin;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, lateralMin, lateralMax), Mathf.Clamp(target.position.y, alturaMin, alturaMax), transform.position.z);
    }
}
