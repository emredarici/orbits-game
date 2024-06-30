using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform currentObject;
    [SerializeField] private Transform[] orbits;
    [SerializeField] private int currentIndex = 0;
    private int direction = 1; // 1 inside, -1 outside
    //Particle
    [SerializeField] private ParticleSystem ChangeOrbitpar;
    [SerializeField] private GameObject DeathOrbitpar;
    //Script
    private OrbitScript orbitScript;
    private GameManager gameManager;
    public UIManager uIManager;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        orbitScript = this.GetComponent<OrbitScript>();
        this.transform.position = orbits[currentIndex].transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentIndex += direction;
            if (currentIndex >= orbits.Length - 1)
            {
                direction = -1;
            }
            else if (currentIndex <= 0)
            {
                direction = 1;
            }
            ChangeOrbitpar.Play();
        }
        currentObject = orbits[currentIndex];
        this.transform.position = Vector3.Lerp(this.transform.position, currentObject.position, 10 * Time.deltaTime);
    }
    private void DeathPlayer()
    {
        orbitScript.orbitRotateSpeed = 0;
        Instantiate(DeathOrbitpar, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        uIManager.StartCoroutine(uIManager.loseGame());
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Planes"))
        {
            DeathPlayer();
        }
        if (collider.CompareTag("Score"))
        {
            gameManager.UpdateScore();
            Destroy(collider.gameObject);
        }
    }

    private void StartCoroutine(Func<IEnumerator> loseGame)
    {
        throw new NotImplementedException();
    }
}
