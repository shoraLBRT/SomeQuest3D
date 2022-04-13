using Invector.vCharacterController;
using UnityEngine;
public class CursorInvisible : MonoBehaviour
{
    [SerializeField]
    private GameObject _character;
    [SerializeField]
    private GameObject _HUDCanvas;

    private bool _cursorModeIsAcitve;
    private void Start()
    {
        _character.GetComponent<vThirdPersonInput>().enabled = true;
        _HUDCanvas.SetActive(true);
        _cursorModeIsAcitve = false;
    }
    private void Update()
    {
        CursorMode(_cursorModeIsAcitve);

        if (Input.GetKeyDown(KeyCode.LeftControl))
            _cursorModeIsAcitve = !_cursorModeIsAcitve;
    }
    private void CursorMode(bool modeActive)
    {
        Cursor.visible = modeActive;
        _character.GetComponent<vThirdPersonInput>().enabled = !modeActive;
        _HUDCanvas.SetActive(!modeActive);
    }
}
