using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CheckPath : MonoBehaviour
{
    [SerializeField] private Text pathText;

    private void Start()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"streamingAssetsPath : {Application.streamingAssetsPath}");
        builder.AppendLine($"persistentDataPath : {Application.persistentDataPath}");
        builder.AppendLine($"temporaryCachePath : {Application.temporaryCachePath}");

        pathText.text = builder.ToString();
    }
}
