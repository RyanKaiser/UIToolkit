using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class UIController : MonoBehaviour
{
    private VisualElement _bottomContainer;
    private Button _openButton;
    private Button _closeButton;

    private VisualElement _scrim;
    private VisualElement _bottomSheet;


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _bottomContainer = root.Q<VisualElement>("Container_Bottom");
        _openButton = root.Q<Button>("Button_Open");
        _closeButton = root.Q<Button>("Button_Close");
        _scrim = root.Q<VisualElement>("Scrim");
        _bottomSheet = root.Q<VisualElement>("BottomSheet");

        _bottomContainer.style.display = DisplayStyle.None;

        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnOpenButtonClicked(ClickEvent e) 
    {
        _bottomContainer.style.display = DisplayStyle.Flex;
        _scrim.AddToClassList("scrim--fadein");
        _bottomSheet.AddToClassList("bottomsheet--up");
    }

    private void OnCloseButtonClicked(ClickEvent e)
    {
        // _bottomContainer.style.display = DisplayStyle.None;
        _scrim.RemoveFromClassList("scrim--fadein");
        _bottomSheet.RemoveFromClassList("bottomsheet--up");
    }
}
