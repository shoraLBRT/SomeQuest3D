using Internal;
using UnityEngine;

public class SpikesArea : MonoBehaviour
{
    private PlayerHP _playerHP;
    private void Start()
    {
        _playerHP = Locator.GetObject<PlayerHP>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHP.TakingDamage(0.2f);
        }
    }
}
