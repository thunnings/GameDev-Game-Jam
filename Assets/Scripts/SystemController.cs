using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SystemController : MonoBehaviour
{
    public GameEvent mouseOver;
    public GameEvent starSystemMouseClick;
    public GameEvent cancelButtonClick;
    public UIDocument starSystemInfoPanel;
    public StarSystem starSystem;

    SpriteRenderer spriteRenderer;
    Button cancelButton;
    Button setDestinationButton;
    StarShip starShip;

    private void Start()
    {
        starSystemInfoPanel.rootVisualElement.visible = false;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        starShip = FindObjectOfType<StarShip>();

        cancelButton = starSystemInfoPanel.rootVisualElement.Q<Button>("cancelButton");
        setDestinationButton = starSystemInfoPanel.rootVisualElement.Q<Button>("setDestinationButton");

        cancelButton.clickable.clicked += CancelButton;
        setDestinationButton.clickable.clicked += SetDestinationButton;

        FormatStarSystemInfoPanel();
    }

    private void FormatStarSystemInfoPanel()
    {
        starSystemInfoPanel.rootVisualElement.Q<Label>("SystemName").text = starSystem.systemName;
        starSystemInfoPanel.rootVisualElement.Q<Label>("SystemDescription").text = "Coordinates: " + starSystem.systemLocation.ToString() + "\n"
            + DistanceFromStarship(starShip) + " lightyears away.";
    }

    public void CancelButton()
    {
        starSystemInfoPanel.rootVisualElement.visible = false;
    }

    private void SetDestinationButton()
    {

    }

    void OnMouseEnter()
    {
        spriteRenderer.color = Color.blue;
        mouseOver.Raise();
    }

    void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }

    private void OnMouseDown()
    {
        starSystemMouseClick.Raise();
        cancelButtonClick.Raise();
        starSystemInfoPanel.rootVisualElement.visible = true;
    }

    private float DistanceFromStarship(StarShip starShip)
    {
        return Vector3.Distance(starShip.GetLocation(), starSystem.systemLocation);
    }
}
