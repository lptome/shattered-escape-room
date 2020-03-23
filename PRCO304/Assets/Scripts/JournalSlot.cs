using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JournalSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text text;
    public event Action<JournalEntry> OnLeftClickEvent;
    public event Action<JournalSlot> OnPointerEnterEvent;
    public event Action<JournalSlot> OnPointerExitEvent;

    private JournalEntry _journalEntry;

    public JournalEntry JournalEntry
    {
        get { return _journalEntry; }
        set
        {
            _journalEntry = value;
            if (_journalEntry == null)
            {
                text.text = null;
            }
            else
            {
                text.text = _journalEntry.entryName;
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (JournalEntry != null && OnLeftClickEvent != null)
            {
                OnLeftClickEvent(JournalEntry);
                Debug.Log("Working.");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }
}
