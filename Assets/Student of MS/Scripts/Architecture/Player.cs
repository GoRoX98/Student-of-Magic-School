using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private Lesson _lesson;

    private void Awake()
    {
        _playerWallet = GetComponent<Wallet>();
        _lesson = GameObject.Find("Table").GetComponent<Lesson>();
    }

    private void OnEnable()
    {
        _lesson.LessonDone += OnLessonDone;
    }

    private void OnDisable()
    {
        _lesson.LessonDone -= OnLessonDone;
    }



    private void OnLessonDone(int amount)
    {
        _playerWallet.GoldAdd(amount);
    }

    public int[] TakeBalance()
    {
        int[] balance = new int[2] {_playerWallet.Gold, _playerWallet.Energy};
        return balance;
    }

    public void Loading(int[] wallet)
    {
        _playerWallet.LoadWallet(wallet);
    }
}
