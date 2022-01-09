using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] bool _startScreenActive = true;
    [SerializeField] bool _playerActive = false;
    [SerializeField] bool _spawnerControllerActive = false;

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

    void Start()
    {
        if(instance == null)
            instance = GetComponent<GameManager>();
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
