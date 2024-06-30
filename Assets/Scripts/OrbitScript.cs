using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public float orbitRotateSpeed;
    [SerializeField] Transform center;
    void Update()
    {
        this.transform.RotateAround(center.position, Vector3.back, orbitRotateSpeed * Time.deltaTime);
    }
}
