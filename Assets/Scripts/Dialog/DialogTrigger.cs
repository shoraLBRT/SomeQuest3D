using UnityEngine;

class DialogTrigger : MonoBehaviour
{
    public DialogContent dialog;
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
