using UnityEngine;
using UnityEngine.UI;

public class OpenNewTab : MonoBehaviour
{
    [SerializeField] private InputField urlInput;
    [SerializeField] private Button openUrlButton;
    
#if UNITY_WEBGL
    //Javascriptの呼び出し
    [DllImport("__Internal")]
    private static extern void OpenNewTabEventOn(string url);
    [DllImport("__Internal")]
    private static extern void OpenNewTabEventOff();
#endif
    
    private void Start()
    {
        var clickedEvent = new Button.ButtonClickedEvent();
        clickedEvent.AddListener(() => OpenUrl(urlInput.text));
        
        openUrlButton.onClick = clickedEvent;
    }

    private void OpenUrl(string url)
    {
#if UNITY_WEBGL
        OpenNewTabEventOn(url);
#else
        Application.OpenURL(url);
#endif  
    }
}
