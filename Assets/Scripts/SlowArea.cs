using UnityEngine;

public class SlowArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Time.timeScale = Time.timeScale/3;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Time.timeScale = Time.timeScale * 3;
    }
}
