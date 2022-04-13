using Internal;
using UnityEngine;
using UnityEngine.UI;

public class BeginEndMessage : MonoBehaviour
{
    [SerializeField]
    private GameObject _beginMessage;
    [SerializeField]
    private GameObject _endMessage;
    private void Awake()
    {
        Locator.Register<BeginEndMessage>(this);
    }
    private void Start()
    {
        _endMessage.SetActive(false);
        _beginMessage.SetActive(true);
        _beginMessage.GetComponent<Image>().CrossFadeAlpha(0, 2f, false);
    }
    public void EndMessage()
    {
        _endMessage.SetActive(true);
        _endMessage.GetComponent<Image>().CrossFadeAlpha(0, 2f, false);
    }
}
