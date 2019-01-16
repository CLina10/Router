using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public RectTransform mainMenu;
    public RectTransform controlMenu;

    //MenuEvents menuEvents;

    void OnEnable()
    {
        MenuEvents menuEvents = GetComponent<MenuEvents>();
        menuEvents.ChangeMenu.AddListener(SetActiveMenu);
    }

    //private void OnDisable()
    //{
    //    menuEvents.ChangeMenu.RemoveListener(SetActiveMenu);
    //}

    public void SetActiveMenu(ActiveMenu activeMenu)
    {
        switch (activeMenu)
        {
            case ActiveMenu.Main:
                mainMenu.SetAsLastSibling();
                break;
            case ActiveMenu.Control:
                controlMenu.SetAsLastSibling();
                break;
            default:
                break;
        }
    }
}