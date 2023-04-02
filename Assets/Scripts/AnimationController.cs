using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerChoiceAnimation;
    [SerializeField]
    private Animator choiceAnimation;

    public void ResetAnimation()
    {
        playerChoiceAnimation.Play("ShowHandler");
        choiceAnimation.Play("RemoveChoices");
    }

    public void PlayerMadeChoice()
    {
         playerChoiceAnimation.Play("RemoveHandler");
         choiceAnimation.Play("ShowChoices");
    }
}
