using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartMenu : MonoBehaviour
{
    public UIDocument titleScreen;

    Button okButton;

    private void Start()
    {
        okButton = titleScreen.rootVisualElement.Q<Button>("okButton");
        okButton.clickable.clicked += OkButton;
    }
    private void OkButton()
    {
        titleScreen.rootVisualElement.visible = false;
    }
}
