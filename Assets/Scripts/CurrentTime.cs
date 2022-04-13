using Internal;
using System;
using UnityEngine;
using UnityEngine.UI;
public class CurrentTime : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentTimeGO;
    private Text _currentTimeText;
    private const string TimeFormat = "HH:mm:ss";
    private void Awake()
    {
        Locator.Register<CurrentTime>(this);
    }
    private void Start()
    {
        _currentTimeText = _currentTimeGO.GetComponent<Text>();
    }
    private void Update()
    {
        _currentTimeText.text = DateTime.Now.ToString(TimeFormat);
    }
}
