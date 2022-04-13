using Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPonScene : MonoBehaviour
{
    private PlayerHP _playerHP;
    public Image PlayerHPBar { get; set; }
    [SerializeField]
    private GameObject _payerHpOnScene;
    private void Awake()
    {
        Locator.Register<PlayerHPonScene>(this);
    }
    private void Start()
    {
        PlayerHPBar = _payerHpOnScene.GetComponent<Image>();
        _playerHP = Locator.GetObject<PlayerHP>();
        RefreshHPValue();
    }
    public void RefreshHPValue()
    {
        PlayerHPBar.fillAmount = _playerHP.PlayerHealth;
    }
}
