using System;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField]
    private GameObject _directionalLight;
    [SerializeField]
    private GameObject _congrats;
    [SerializeField]
    private GameObject _easterEgg;
    private void Start()
    {
        _easterEgg.SetActive(false);
        _congrats.SetActive(false);
    }
    private void Update()
    {
        if (DateTime.Now.Second % 10 == 0)
        {
            _easterEgg.SetActive(true);
        }
        else _easterEgg.SetActive(false);
    }
    public void EggIsCollected()
    {
        _directionalLight.GetComponent<Light>().intensity = 30;
        _directionalLight.GetComponent<Light>().color = Color.red;
        _congrats.SetActive(true);
        Invoke(nameof(LightToDefault), 2);
    }
    private void LightToDefault()
    {
        _directionalLight.GetComponent<Light>().intensity = 1;
        _directionalLight.GetComponent<Light>().color = Color.white;
        _congrats.SetActive(false);
    }
}
