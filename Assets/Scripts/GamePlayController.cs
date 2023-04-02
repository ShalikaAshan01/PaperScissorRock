using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum GameChoices
{
    None = -1,
    Paper = 0,
    Rock = 1,
    Scissor = 2
}public enum WinState
{
    Draw,Win,Lose
}

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private Sprite rockSprite;
    [SerializeField] private Sprite paperSprite;
    [SerializeField] private Sprite scissorSprite;
    [SerializeField] private Image playerChoiceImg;
    [SerializeField] private Image opponentChoiceImg;
    [SerializeField] private TextMeshProUGUI infoTxt;
    [SerializeField] private TextMeshProUGUI YourScoreTxt;
    [SerializeField] private TextMeshProUGUI OpponentScoreTxt;
    [SerializeField] private TextMeshProUGUI RoundsTxt;
    private GameChoices playerChoice = GameChoices.None;
    private GameChoices opponentChoice = GameChoices.None;
    private AnimationController animationController;
    private int rounds = 0;
    private int yourWin = 0;
    private int opponentWin = 0;
    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(GameChoices selectedChoice)
    {
        playerChoice = selectedChoice;
        switch (selectedChoice)
        {
            case GameChoices.Paper:
                playerChoiceImg.sprite = paperSprite;
                break;
            case GameChoices.Rock:
                playerChoiceImg.sprite = rockSprite;
                break;
            case GameChoices.Scissor:
                playerChoiceImg.sprite = scissorSprite;
                break;
        }

        SetOpponentChoice();
        DetermineWinner();
    }

    private void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3);
        opponentChoice = (GameChoices)rnd;
        switch (opponentChoice)
        {
            case GameChoices.Paper:
                opponentChoiceImg.sprite = paperSprite;
                break;
            case GameChoices.Rock:
                opponentChoiceImg.sprite = rockSprite;
                break;
            case GameChoices.Scissor:
                opponentChoiceImg.sprite = scissorSprite;
                break;
        }
    }

    private void DetermineWinner()
    {
        rounds++;
        RoundsTxt.text = rounds.ToString();
        if (playerChoice == opponentChoice)
        {
            infoTxt.text = "It's a Draw!";
            StartCoroutine(DisplayWinnerAndRestart(WinState.Draw));
            return;
        }

        switch (opponentChoice)
        {
            case GameChoices.Paper:
                if (playerChoice == GameChoices.Scissor)
                {
                    PlayerWon();
                    return;
                }

                OpponentWon();
                return;
            case GameChoices.Rock:
                if (playerChoice == GameChoices.Paper)
                {
                    PlayerWon();
                    return;
                }

                OpponentWon();
                return;
            case GameChoices.Scissor:
                if (playerChoice == GameChoices.Rock)
                {
                    PlayerWon();
                    return;
                }

                OpponentWon();
                return;
        }
    }

    private void PlayerWon()
    {
        infoTxt.text = "You Win!";

        StartCoroutine(DisplayWinnerAndRestart(WinState.Win));
    }

    private void OpponentWon()
    {
        infoTxt.text = "You Lose!";
        StartCoroutine(DisplayWinnerAndRestart(WinState.Lose));
    }

    IEnumerator DisplayWinnerAndRestart(WinState winState)
    {
        yield return new WaitForSeconds(0.5f);
        infoTxt.gameObject.SetActive(true);
        switch (winState)
        {
            case WinState.Win:
                yourWin++;
                YourScoreTxt.text = yourWin.ToString();
                break;
            case WinState.Lose:
                opponentWin++;
                OpponentScoreTxt.text = opponentWin.ToString();
                break;
            case WinState.Draw:
            default:
                break;
        }
        yield return new WaitForSeconds(0.5f);
        infoTxt.gameObject.SetActive(false);

        animationController.ResetAnimation();
    }
}