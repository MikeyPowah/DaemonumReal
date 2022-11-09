using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonContinue : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.Open();
        else _interactionPromptUI.Close();
    }
}
