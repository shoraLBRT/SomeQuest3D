using Internal;
using UnityEngine;
using UnityEngine.UI;

public class CurrentQuest : MonoBehaviour
{
    [SerializeField]
    private GameObject _questTextOnScene;

    [SerializeField]
    private GameObject _questCompleted;
    [SerializeField]
    private GameObject _questStarted;

    private void Awake()
    {
        Locator.Register<CurrentQuest>(this);
        _questCompleted.SetActive(false);
        _questStarted.SetActive(true);
    }
    public void ChangeQuestText(string questText)
    {
        _questCompleted.SetActive(false);
        _questStarted.SetActive(true);
        _questTextOnScene.GetComponent<Text>().text = questText;
    }
    public void QuestCompleted(string questText)
    {
        _questTextOnScene.GetComponent<Text>().text = questText;
        _questStarted.SetActive(false);
        _questCompleted.SetActive(true);
    }
}
