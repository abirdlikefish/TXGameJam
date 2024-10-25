using Pec;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : Singleton<UIMainMenu>
{
    public Animator duelAnimator;
    public Animator exitAnimator;


    public UIButton DuelButton;
    public UIButton ExitButton;

    public override void Init()
    {
        DuelButton.OnHighlight += () => duelAnimator.SetTrigger("Highlighted");
        DuelButton.OnClick += () => {
            EventManager.Instance.ExitState(0);
            Destroy(gameObject);
        };
        DuelButton.OnExit += () => duelAnimator.SetTrigger("Normal");

        ExitButton.OnClick += () => exitAnimator.SetTrigger("Pressed");
        ExitButton.OnHighlight += () => exitAnimator.SetTrigger("Highlighted");
        ExitButton.OnExit += () => {
            Application.Quit();
            exitAnimator.SetTrigger("Normal"); 
        };
    }
}
