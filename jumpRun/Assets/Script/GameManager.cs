using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    public Text bestText;
    public GameObject gameoverUI;

    private float score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�");
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if(isGameover&&Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void AddScore(float newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + (int)score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("Best");

        if(score>bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("Best", bestScore);
        }

        bestText.text = "Best Score : " + (int)bestScore;
    }
}