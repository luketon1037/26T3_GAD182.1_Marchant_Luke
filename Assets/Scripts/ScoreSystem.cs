using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    private int totalScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UpdateScoreDisplay();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        Debug.Log("Score Increased! Total Score: " + totalScore);
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore}";
        }
    }
}
