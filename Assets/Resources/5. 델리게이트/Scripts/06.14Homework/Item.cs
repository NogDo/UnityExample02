using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum EItemType
{
    WEAPON,
    USE,
    EQUIPMENT,
    OTHER
}

public class Item : MonoBehaviour
{
    #region public º¯¼ö
    public List<EItemType> itemType;
    public Image image;
    #endregion

    void Awake()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry click = new EventTrigger.Entry();
        click.eventID = EventTriggerType.PointerClick;
        click.callback.AddListener
            (
                (data) =>
                {
                    transform.parent.GetComponent<CInventoryManager>().RemoveItem(gameObject);
                    Destroy(gameObject);
                }
            );

        eventTrigger.triggers.Add(click);
    }
}
