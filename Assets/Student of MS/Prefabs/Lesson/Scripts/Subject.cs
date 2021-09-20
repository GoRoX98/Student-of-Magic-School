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
    private Lesson _lesson;

    private void Awake()
    {
        _lesson = GameObject.Find("Table").GetComponent<Lesson>();
    }

    private void FixedUpdate()
    {
        if (_subject.TakeHard() <= 0)
        {
            List<GameObject> listSubjects = GameObject.Find("Table").GetComponent<Lesson>().SubjectsOnTable;
            if (_subject.Name == _lesson.LessonSubject.Name) _lesson.AddProgress(_progress);
            else _lesson.AddFail();
            for (int i = 0; i < listSubjects.Count; i++) if (gameObject == listSubjects[i]) listSubjects[i] = null;
            Destroy(gameObject);
        }
    }

    public void SetSubject(SubjectStruct NewSubject)
    {
        _subject = NewSubject;
        _progress = _subject.TakeHard();
        gameObject.GetComponent<SpriteRenderer>().sprite = _subject.Sprite[Random.Range(0, _subject.Sprite.Count)];
    }

    public void Click()
    {
        _subject.Action();
    }

    public string SubjectName()
    {
        return _subject.Name;
    }
}
