using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Content : MonoBehaviour
{

    [SerializeField]
    private List<SubjectStruct> _subjects = new List<SubjectStruct>();


    public SubjectStruct TakeSubject()
    {
        int i = Random.Range(0, _subjects.Count);
        return _subjects[i];
    }

}
