using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    private VisualElement _bottomContainer;
    private Button _openButton;
    private Button _closeButton;

    private VisualElement _scrim;
    private VisualElement _bottomSheet;

    private VisualElement _boy;
    private VisualElement _girl;
    private Label _message;


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

        _boy = root.Q<VisualElement>("Image_Boy");
        _girl = root.Q<VisualElement>("Image_Girl");
        _message = root.Q<Label>("Label_Message");

        // AnimateBoy();
        Invoke("AnimateBoy", 1);

        _bottomSheet.RegisterCallback<TransitionEndEvent>(OnBottomSheetDown);
        
    }
   
    void AnimateBoy()
    {
        _boy.RemoveFromClassList("image--boy--inair");
    }

    void AnimateGirl()
    {
        _girl.ToggleInClassList("image--girl--up");
        _girl.RegisterCallback<TransitionEndEvent>(
            evt => _girl.ToggleInClassList("image--girl--up")
        );

        _message.text = string.Empty;
        string m = "\"Sed in rebus apertissimis nimium longi sumus.\"";
        DOTween.To(() => _message.text, x => _message.text = x, m, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_boy.ClassListContains("image--boy--inair"));
    }

    private void OnOpenButtonClicked(ClickEvent e) 
    {
        _bottomContainer.style.display = DisplayStyle.Flex;
        _scrim.AddToClassList("scrim--fadein");
        _bottomSheet.AddToClassList("bottomsheet--up");

        AnimateGirl();
    }

    private void OnCloseButtonClicked(ClickEvent e)
    {
        
        _scrim.RemoveFromClassList("scrim--fadein");
        _bottomSheet.RemoveFromClassList("bottomsheet--up");
    }

    private void OnBottomSheetDown(TransitionEndEvent evt)
    {
        if (!_bottomSheet.ClassListContains("bottomsheet--up"))
        {
            _bottomContainer.style.display = DisplayStyle.None;
        }
        
    }
}
