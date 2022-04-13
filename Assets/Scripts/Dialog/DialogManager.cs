using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _firstDialogButton;
    [SerializeField]
    private GameObject _lastDialogButton;
    [SerializeField]
    private GameObject _dialogWindow;
    [SerializeField]
    private Text NameTextForTyping;
    [SerializeField]
    private Text DialogTextForTyping;

    private Queue<string> sentences;
    private Queue<string> names;

    public bool DialogIsTriggered { get; set; } = false;
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        _dialogWindow.SetActive(false);
        _firstDialogButton.SetActive(false);
        _lastDialogButton.SetActive(false);
    }
    // В методе StartDialog мы сначала расчищаем очереди, а потом заполняем их из массива в классе DiologParametrs, мнгновенно запуская отображение первого предложения.
    public void StartDialog(DialogContent dialog)
    {
        _dialogWindow.SetActive(true);
        sentences.Clear();
        names.Clear();

        foreach (string name in dialog.names)
        {
            names.Enqueue(name);
        }
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 & names.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeName(name));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogTextForTyping.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogTextForTyping.text += letter;
            yield return null;
        }
    }
    IEnumerator TypeName(string name)
    {
        NameTextForTyping.text = "";
        foreach (char letter in name.ToCharArray())
        {
            NameTextForTyping.text += letter;
            yield return null;
        }
    }
    private void EndDialog()
    {
        _dialogWindow.SetActive(false);
        _firstDialogButton.SetActive(false);
        _lastDialogButton.SetActive(false);
    }
}
