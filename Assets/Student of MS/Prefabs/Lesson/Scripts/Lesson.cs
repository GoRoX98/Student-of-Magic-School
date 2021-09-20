using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson : MonoBehaviour
{

    public GameObject PrefabSubject;
    public List<GameObject> SpawnPoints = new List<GameObject>();
    public List<GameObject> SubjectsOnTable = new List<GameObject>();
    public SubjectStruct LessonSubject;
    [SerializeField] private bool _lessonOn = false;
    [SerializeField] private int _lessonHard = 2;
    [SerializeField] private int _progress = 0;
    [SerializeField] private int _fails = 0;
    private GameObject _camera;
    private bool _haveLessonSubject = false;

    public event UnityAction<int> LessonDone;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void FixedUpdate()
    {
        if(_lessonOn == true) LessonOn();
    }

    private void SpawnSubject(int i)
    {
        GameObject newSubject = Instantiate(PrefabSubject);
        //Проверка содержимого на столе
        for (int x = 0; x < SubjectsOnTable.Count; x++)
        {
            if (SubjectsOnTable[x] != null)
            {
                if (SubjectsOnTable[x].GetComponent<Subject>().SubjectName() == LessonSubject.Name)
                {
                    _haveLessonSubject = true;
                    break;
                }
            }
            else _haveLessonSubject = false;
        }
        //Обязательный спавн хотя бы 1-го предмета
        if (_haveLessonSubject == false && (i == 2 || SubjectsOnTable.Count == 3)) newSubject.GetComponent<Subject>().SetSubject(LessonSubject);
        else newSubject.GetComponent<Subject>().SetSubject(_camera.GetComponent<Content>().TakeSubject());
        
        newSubject.transform.position = SpawnPoints[i].transform.position;
        if (SubjectsOnTable.Count < 3) SubjectsOnTable.Add(newSubject);
        else SubjectsOnTable[i] = newSubject;
    }

    private void ClearTable()
    {
        for (int i = 0; i < SubjectsOnTable.Count; i++) Destroy(SubjectsOnTable[i]);
    }

    private void LessonOn()
    {
        if (GameObject.FindGameObjectsWithTag("Subject").Length < 3)
        {
            for (int i = 0; i < SubjectsOnTable.Count; i++)
            {
                if (SubjectsOnTable[i] == null)
                {
                    SpawnSubject(i);
                }
            }
        }
        if ((_progress >= _lessonHard * 5) || _fails >= 3)
        {
            LessonEnd();
        }
    }

    private void LessonEnd()
    {
        print("Lesson is done");
        GameObject.Find("Canvas").transform.Find("Lesson").gameObject.SetActive(false);

        if (_fails >= 3) LessonDone?.Invoke(0);
        else LessonDone?.Invoke(_progress / 2);
        _progress = 0;
        _lessonOn = false;
        _fails = 0;
        for (int i = 0; i < SubjectsOnTable.Count; i++) Destroy(SubjectsOnTable[i]);
    }

    public void AddProgress(int Progress)
    {
        _progress += Progress;
        ClearTable();
    }

    public void AddFail()
    {
        _fails++;
        ClearTable();
    }

    public void StartLesson()
    {
        _lessonOn = true;
        LessonSubject = _camera.GetComponent<Content>().TakeSubject();
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            SpawnSubject(i);
        }
    }
}
