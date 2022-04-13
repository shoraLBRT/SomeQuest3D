using Internal;
using UnityEngine;

public class QUESTSlowMotion : MonoBehaviour
{
    private CurrentQuest _currentQuest;

    private float _timeRemaining = 10f;
    private bool _questAcivated = false;

    public float TimeRemaining
    {
        get => _timeRemaining;
        set
        {
            if (TimeRemaining < 0)
                TimeRemaining = 0;
            _timeRemaining = value;
        }
    }

    public bool QuestCompleted { get; set; } = false;

    private void Start()
    {
        _currentQuest = Locator.GetObject<CurrentQuest>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SlowMotionQuest") && !QuestCompleted)
        {
            _questAcivated = true;
            other.gameObject.SetActive(false);
            _currentQuest.ChangeQuestText("Зайди и не выходи с территории SlowMotionArea на протяжении 10 секунд. Осталось: " + TimeRemaining.ToString("##.#"));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SlowMotionArea") && !QuestCompleted && _questAcivated)
        {
            QuestTimer();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SlowMotionArea") && TimeRemaining > 1f)
        {
            TimeRemaining = 10f;
            _currentQuest.ChangeQuestText("Чел, ты же не просидел там 10 секунд, давай по честному. Осталось: " + TimeRemaining.ToString("##.#"));
        }
    }
    private void QuestTimer()
    {
        _currentQuest.ChangeQuestText("Зайди и не выходи с территории SlowMotionArea на протяжении 10 секунд. Осталось: " + TimeRemaining.ToString("##.#"));
        if (TimeRemaining > 0)
            TimeRemaining -= Time.deltaTime * 5f;

        if (TimeRemaining <= 0f)
        {
            QuestCompleted = true;
            _questAcivated = false;
            _currentQuest.QuestCompleted("Теперь ты знаешь что время относительно.");
        }
    }
}
