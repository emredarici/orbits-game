using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float[] Spawn_radius;

    private void Awake()
    {
        center = GameObject.Find("GameManager").transform;
        this.transform.SetParent(center);
        transform.position = Vector3.right * Spawn_radius[Random.Range(0, Spawn_radius.Length)];
        center.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

    }
}
