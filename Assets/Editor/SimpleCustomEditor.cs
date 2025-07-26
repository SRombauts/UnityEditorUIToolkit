using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/Editor Windows/SimpleCustomEditor")]
    public static void ShowExample()
    {
        SimpleCustomEditor wnd = GetWindow<SimpleCustomEditor>();
        wnd.titleContent = new GUIContent("SimpleCustomEditor");
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
        Button myButton = rootVisualElement.Q<Button>("button1");
        if (myButton != null)
        {
            myButton.clicked += () => Debug.Log("Button clicked!");
        }
        else
        {
            Debug.LogError("Button with name 'button1' not found in UXML.");
        }
    }
}
