using Internal;
using UnityEngine;

public class QUESTLastDialog : MonoBehaviour
{
    private CurrentQuest _currentQuest;

    private QUESTFirstBlood _firstQuest;
    private QUESTSlowMotion _secondQuest;

    [SerializeField]
    private GameObject _lastDialogButton;

    private void Start()
    {
        _lastDialogButton.SetActive(false);
        _currentQuest = Locator.GetObject<CurrentQuest>();

        _firstQuest = GetComponent<QUESTFirstBlood>();
        _secondQuest = GetComponent<QUESTSlowMotion>();
    }
    private void Update()
    {
        if (_firstQuest.QuestCompleted && _secondQuest.QuestCompleted)
            _currentQuest.ChangeQuestText("Молодец, ты выполнил 2 квеста, иди к выходу");
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log(_firstQuest.QuestCompleted);
            Debug.Log(_secondQuest.QuestCompleted);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("QuestionArea") && _firstQuest.QuestCompleted && _secondQuest.QuestCompleted)
        {
            _lastDialogButton.SetActive(true);

        }
    }
}
