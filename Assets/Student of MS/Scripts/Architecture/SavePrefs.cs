using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{ 
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
    }

    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("Saved", "Game Saved");
        PlayerPrefs.SetInt("Gold", _player.TakeBalance()[0]);
        PlayerPrefs.SetInt("Energy", _player.TakeBalance()[1]);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Saved"))
        {
            int[] balance = new int[2];
            balance[0] = PlayerPrefs.GetInt("Gold");
            balance[1] = PlayerPrefs.GetInt("Energy");
            _player.Loading(balance);
        }
        else print("No data for load");
    }
}
