using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents : MonoBehaviour
{
    private Lesson _lesson;
    private Player _player;
    //0 - gold; 1 - energy
    public List<Text> ResourcesUI;

    private void Awake()
    {
        _lesson = GameObject.Find("Table").GetComponent<Lesson>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnEnable()
    {
        _lesson.LessonDone += OnLessonDone;
    }

    private void OnDisable()
    {
        _lesson.LessonDone -= OnLessonDone;
    }


    private void FixedUpdate()
    {
        ResourcesUI[0].text = $"Gold: {_player.TakeBalance()[0]}";
        ResourcesUI[1].text = $"Energy: {_player.TakeBalance()[1]}";
    }

    public void UPDSubjectUI(GameObject SubjectUI)
    {
        SubjectUI.GetComponent<Image>().sprite = _lesson.LessonSubject.Sprite[0];
    }

    private void OnLessonDone(int ammount)
    {
        GameObject EndUI = GameObject.Find("Canvas").transform.Find("End Lesson").gameObject;
        GameObject Win = EndUI.transform.Find("Win").gameObject;
        if (ammount == 0)
        {
            EndUI.transform.Find("Text").GetComponent<Text>().text = "The lesson was failed!";
            Win.SetActive(false);
        }
        else
        {
            EndUI.transform.Find("Text").GetComponent<Text>().text = "The lesson was completed successfully!";
            Win.GetComponent<Text>().text = $"You earned - {ammount} gold";
            Win.SetActive(true);
        }
        EndUI.SetActive(true);
    }

}
