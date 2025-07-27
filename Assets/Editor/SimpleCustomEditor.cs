using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using PopupWindow = UnityEditor.PopupWindow;

public class SimpleCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/Editor Windows/Simple Custom Editor")]
    public static void ShowExample()
    {
        var window = GetWindow<SimpleCustomEditor>();
        window.titleContent = new GUIContent("Simple Custom Editor");
    }

    public void CreateGUI()
    {
        // Instantiate the Editor Window entirely from it's UXML definition.
        var elementsFromUxml = m_VisualTreeAsset.Instantiate();
        rootVisualElement.Add(elementsFromUxml);

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        // Notes: creating elements in code is not recommended for complex UIs, prefer using UXML.
        // Doing so prevent using the UI Builder to design the UI.
        // var label = new Label("Hello World! From C#");
        // rootVisualElement.Add(label);

        SetupButton1Handler();
        SetupPopupButtonHandler();
    }

    void SetupButton1Handler()
    {
        // Find the button in the UXML and set up a click handler
        var button = rootVisualElement.Q<Button>("button1");
        button.RegisterCallback<ClickEvent>(OnButtonClick);
    }

    void OnButtonClick(ClickEvent evt)
    {
        Debug.Log("Button was clicked!");
        m_ClickCount++;

        var label = rootVisualElement.Q<Label>("label1");
        var toggle = rootVisualElement.Q<Toggle>("toggle1");
        if (toggle.value == true)
            label.text = "Button clicked " + m_ClickCount + " times.";
        else
            label.text = "";
    }

    void SetupPopupButtonHandler()
    {
        var button = rootVisualElement.Q<Button>("popupButton");
        button.clicked += () => OpenPopupWindow(button);
    }

    void OpenPopupWindow(Button button)
    {
        PopupWindow.Show(button.worldBound, new PopupContentExample());
    }

    private int m_ClickCount = 0;
}
