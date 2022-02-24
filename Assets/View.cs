using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private Canvas canvas;
    private CanvasGroup group;
    public Selectable FirstSelection;

    public void Start()
    {
        canvas = GetComponent<Canvas>();
        group = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        canvas.enabled = true;
        group.interactable = true;
        FirstSelection.Select();
    }

    public void Hide()
    {
        canvas.enabled = false;
        group.interactable = false;
    }
}
