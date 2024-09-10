using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NavBarController : MonoBehaviour
{
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject scrolls;
    [SerializeField] GameObject canvas;
    private Animator buttonsAnimator; 
    private Animator scrollsAnimator; 
    public Animator canvasAnimator; 

    public int viewState;
    

    private void Start() {

        buttonsAnimator = buttons.GetComponent<Animator>();
        scrollsAnimator = scrolls.GetComponent<Animator>();
        canvasAnimator = canvas.GetComponent<Animator>();
        viewState = 0;
    }

    public void ChangeState(int num)
    {
        buttonsAnimator.SetInteger("State", num);
        scrollsAnimator.SetInteger("State", num);
        viewState = num;
    }

    public void ChangeToButtonState()
    {
        canvasAnimator.SetInteger("State", 0);
    }

    


}





