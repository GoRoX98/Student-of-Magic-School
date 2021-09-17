using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour
{

    public void Click(GameObject Subject)
    {
        Subject.GetComponent<Subject>().Click();
    }
}
