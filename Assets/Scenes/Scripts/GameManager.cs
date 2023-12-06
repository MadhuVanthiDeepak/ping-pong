using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private TMP_Text playerScoreText;
    [SerializeField] private TMP_Text computerScoreText;
  //  private AudioSource audio;

    private int playerScore;
    private int computerScore;

    private void Start()
    {
      //  audio = GetComponent<AudioSource>();
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
    }

    public void OnPlayerScored()
    {
      //  audio.Play();
        SetPlayerScore(playerScore + 1);
        NewRound();
    }

    public void OnComputerScored()
    {
        //audio.Play();
        SetComputerScore(computerScore + 1);
        NewRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
