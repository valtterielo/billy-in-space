using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool _startScreenActive = true;
    bool _playerActive = false;
    bool _spawnerControllerActive = false;
    int _playThroughs = 0;

    public bool startScreenActive
    {
        get { return _startScreenActive; }
        set { _startScreenActive = value; }
    }
    public bool playerActive
    {
        get { return _playerActive; }
        set { _playerActive = value; }
    }
    public bool spawnerControllerActive
    {
        get { return _spawnerControllerActive; }
        set { _spawnerControllerActive = value; }
    }
    public int playthroughs
    {
        get { return _playThroughs; }
        set { _playThroughs = value; }
    }

    void Start()
    {
        if(instance == null)
            instance = GetComponent<GameManager>();
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
