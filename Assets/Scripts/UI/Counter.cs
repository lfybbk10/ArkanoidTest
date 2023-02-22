using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI _text;

    protected void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    protected void UpdateText(int value)
    {
        _text.SetText(value.ToString());
    }
}
