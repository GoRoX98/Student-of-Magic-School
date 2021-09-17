using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lesson : MonoBehaviour
{

    [SerializeField] private Clicker _clicker;
    public GameObject PrefabSubject;
    public List<GameObject> SpawnPoints = new List<GameObject>();
    public List<GameObject> SubjectsOnTable = new List<GameObject>();
    [SerializeField] private int _lessonHard = 2;
    [SerializeField] private int _progress = 0; 
    private GameObject _camera;

    public event UnityAction<int> LessonDone;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _clicker = _camera.GetComponent<Clicker>();
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            SpawnSubject(i);
        }
    }

    private void FixedUpdate()
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
        if (_progress >= _lessonHard*5)
        {
            print("Lesson is done");
            LessonDone?.Invoke(_progress / 2);
            _progress = 0;
        }
    }

    private void SpawnSubject(int i)
    {
        GameObject newSubject = Instantiate(PrefabSubject);
        newSubject.GetComponent<Subject>().SetSubject(_camera.GetComponent<Content>().TakeSubject());
        newSubject.transform.position = SpawnPoints[i].transform.position;
        if (SubjectsOnTable.Count < 3) SubjectsOnTable.Add(newSubject);
        else SubjectsOnTable[i] = newSubject;
    }

    public void AddProgress(int Progress)
    {
        _progress += Progress;
    }
}
