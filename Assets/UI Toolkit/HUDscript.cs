using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDscript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var button = root.Q<Button>("button1");
        button.RegisterCallback<ClickEvent>(ButtonOneClick);
    }
    private void ButtonOneClick(ClickEvent evt)
    {
        Debug.Log("400 FrancisBucks deposited");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
