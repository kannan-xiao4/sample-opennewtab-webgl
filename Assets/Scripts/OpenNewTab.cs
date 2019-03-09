using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class OpenNewTab : MonoBehaviour
{
    [SerializeField] private InputField urlInput;
    [SerializeField] private Button openUrlButton;
    
#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void Hello();    
    [DllImport("__Internal")]
    private static extern void OpenNewTabFn(string url);
#endif
    
    private void Start()
    {
#if UNITY_WEBGL
        Hello();
#endif
        var clickedEvent = new Button.ButtonClickedEvent();
        clickedEvent.AddListener(() => OpenUrl(urlInput.text));
        
        openUrlButton.onClick = clickedEvent;
    }

    private void OpenUrl(string url)
    {
#if UNITY_WEBGL
        OpenNewTabFn(url);
#else
        Application.OpenURL(url);
#endif  
    }
}
