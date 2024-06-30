using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scorePrefab;
    private void Awake()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    void Start()
    {

    }
    void Update()
    {

    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        SpawnScore();
    }
    private void SpawnScore()
    {
        Instantiate(scorePrefab);
    }
}
