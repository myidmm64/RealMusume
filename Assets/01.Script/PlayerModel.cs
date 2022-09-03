using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private Action _deleteAction = null;

    public void ActionAdd(Action action)
    {
        _deleteAction += action;
    }

    private void OnMouseDown()
    {
        _deleteAction?.Invoke();
    }
}
