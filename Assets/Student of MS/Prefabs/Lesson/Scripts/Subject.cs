using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(SpriteRenderer))]
public class Subject : MonoBehaviour
{

    [SerializeField]
    private SubjectStruct _subject;
    [SerializeField] private int _progress;

    private void FixedUpdate()
    {
        if (_subject.TakeHard() == 0)
        {
            List<GameObject> listSubjects = GameObject.Find("Table").GetComponent<Lesson>().SubjectsOnTable;
            GameObject.Find("Table").GetComponent<Lesson>().AddProgress(_progress);
            for (int i = 0; i < listSubjects.Count; i++) if (gameObject == listSubjects[i]) listSubjects[i] = null;
            Destroy(gameObject);
        }
    }

    public void SetSubject(SubjectStruct NewSubject)
    {
        _subject = NewSubject;
        _progress = _subject.TakeHard();
        gameObject.GetComponent<SpriteRenderer>().sprite = _subject.Sprite;
    }

    public void Click()
    {
        _subject.Action();
    }
}
