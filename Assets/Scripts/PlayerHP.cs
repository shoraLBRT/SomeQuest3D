using Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    private CurrentQuest _currentQuest;
    private PlayerHPonScene _playerHPonScene;
    private BeginEndMessage _beginEndMessage;
    [HideInInspector]
    public float Damage;

    [SerializeField]
    private float _playerHealth = 1;
    public float PlayerHealth
    {
        get { return _playerHealth; }
        set
        {
            if (value <= 0)
            {
                value = 0;
                DeathProcess();
            }

            _playerHealth = value;
        }
    }
    private void Awake()
    {
        Locator.Register<PlayerHP>(this);
    }
    private void Start()
    {
        _beginEndMessage = Locator.GetObject<BeginEndMessage>();
        _currentQuest = Locator.GetObject<CurrentQuest>();
        _playerHPonScene = Locator.GetObject<PlayerHPonScene>();

    }
    public void TakingDamage(float Damage)
    {
        PlayerHealth -= Damage;
        _playerHPonScene.RefreshHPValue();
    }
    private void DeathProcess()
    {
        Invoke(nameof(RestartLVL), 3);
        _currentQuest.ChangeQuestText("ТЫ УМЕР");
        _beginEndMessage.EndMessage();
    }
    private void RestartLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
