using UnityEngine;

[System.Serializable]
public class DialogContent
{
    public string[] names;
    [TextArea(3, 10)]
    public string[] sentences;
}
