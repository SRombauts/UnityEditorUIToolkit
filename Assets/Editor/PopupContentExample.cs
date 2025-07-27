using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupContentExample : PopupWindowContent
{
    public override void OnOpen()
    {
        Debug.Log("PopupContentExample.OnOpen()");
    }

    public override VisualElement CreateGUI()
    {
        return AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/PopupContentExample.uxml").CloneTree();
    }

    public override void OnClose()
    {
        Debug.Log("PopupContentExample.OnClose()");
    }
}
