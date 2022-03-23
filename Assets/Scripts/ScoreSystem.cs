using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private bool shouldCount = true;
    private float score;

    void Update()
    {
        if (!shouldCount)
        {
            return;
        }

        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void StartScore()
    {
        shouldCount = true;
    }

    public int StopScore()
    {
        shouldCount = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
}
