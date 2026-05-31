using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    private bool isGameOver = false;
    private bool isGameWin = false;
    void Start()
    {
        //Time.timeScale = 1;
        UpdateScore();
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore (int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            UpdateScore();
        }
        
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void GameWin()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
