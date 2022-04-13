using Internal;
using UnityEngine;

public class QUESTManual : MonoBehaviour
{
    private CurrentQuest _currentQuest;
    [SerializeField]
    private GameObject _manualDialogButton;
    public bool QuestCompleted { get; set; } = false;

    private void Start()
    {
        _manualDialogButton.SetActive(false);
        _currentQuest = Locator.GetObject<CurrentQuest>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ManualQuest"))
        {
            other.gameObject.SetActive(false);
            _manualDialogButton.SetActive(true);
            _currentQuest.ChangeQuestText("Нажми на левый Ctrl, чтобы войти в CursorMode. После чего нажми на знак вопроса");
        }
    }
}
