using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SubjectStruct
{

    public string Name;
    //How many clicks needs
    [SerializeField]
    private int _subjectHard;
    public Sprite Sprite;

    public SubjectStruct (string Name, int Hard, Sprite Sprite)
    {
        this.Name = Name;
        _subjectHard = Hard;
        this.Sprite = Sprite;
    }

    public int TakeHard()
    {
        return _subjectHard;
    }

    public void Action()
    {
        _subjectHard--;
    }
}
