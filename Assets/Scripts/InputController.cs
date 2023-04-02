using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private AnimationController animationController;

    private GamePlayController _gamePlayController;

    private string playerController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        _gamePlayController = GetComponent<GamePlayController>();
    }

    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        GameChoices selectedChoice = GameChoices.None;

        switch (choiceName.ToLower())
        {
            case "rock":
                selectedChoice = GameChoices.Rock;
                break;
            case "paper":
                selectedChoice = GameChoices.Paper;
                break;
            case "scissor":
                selectedChoice = GameChoices.Scissor;
                break;
        }
        Debug.Log("Selected: " + selectedChoice);
        _gamePlayController.SetChoices(selectedChoice);
        animationController.PlayerMadeChoice();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
