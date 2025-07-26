using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/Editor Windows/Simple Custom Editor")]
    public static void ShowExample()
    {
        SimpleCustomEditor wnd = GetWindow<SimpleCustomEditor>();
        wnd.titleContent = new GUIContent("Simple Custom Editor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        // Notes: creating elements in code is not recommended for complex UIs, prefer using UXML.
        // Doing so prevent using the UI Builder to design the UI.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement elementsFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(elementsFromUXML);

        SetupButtonHandler();
    }

    void SetupButtonHandler()
    {
        // Find the button in the UXML and set up a click handler
        Button button1 = rootVisualElement.Query<Button>("button1");
        button1.RegisterCallback<ClickEvent>(OnButtonClick);
    }

    void OnButtonClick(ClickEvent evt)
    {
        Debug.Log("Button was clicked!");
        m_ClickCount++;

        Label label = rootVisualElement.Query<Label>("label1");
        Toggle toggle = rootVisualElement.Query<Toggle>("toggle1");
        if (toggle.value == true)
            label.text = "Button clicked " + m_ClickCount + " times.";
        else
            label.text = "";
    }

    private int m_ClickCount = 0;
}
