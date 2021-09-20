using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SubjectStruct
{

    public string Name;
    public int Id;
    //How many clicks needs
    [SerializeField]
    private int _subjectHard;
    public List<Sprite> Sprite;

    public SubjectStruct (string Name, int Id, int Hard, List<Sprite> Sprite)
    {
        this.Name = Name;
        this.Id = Id;
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
