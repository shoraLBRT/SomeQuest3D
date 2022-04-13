using Internal;
using UnityEngine;

public class QUESTFirstBlood : MonoBehaviour
{
    private CurrentQuest _currentQuest;

    private bool _questActivated = false;

    public bool QuestCompleted { get; set; } = false;

    private void Start()
    {
        _currentQuest = Locator.GetObject<CurrentQuest>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FirstBloodQuest"))
        {
            other.gameObject.SetActive(false);
            _currentQuest.ChangeQuestText("Иди и получи первый урон на шипах!");
            _questActivated = true;
        }

        if ((_questActivated) && other.gameObject.CompareTag("Enemy"))
        {
            _currentQuest.QuestCompleted("Хорош! Теперь ты знаешь, что такое боль!");
            _questActivated = false;
            QuestCompleted = true;
        }
    }
}
