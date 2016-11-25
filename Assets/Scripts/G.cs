using UnityEngine;

public sealed class G
{
    private static volatile G _instance;
    private PlayerControler _playerControler;
    private BossControler _bossControler;
    private CameraControler _cameraControler;
    private GameManager _gameManager;

    public static G Sys
    {
        get
        {
            if (_instance == null)
                _instance = new G();
            return _instance;
        }
    }

    public void clear()
    {
        _playerControler = null;
        _bossControler = null;
        _cameraControler = null;
        _gameManager = null;
    }

    public PlayerControler playerControler
    {
        get { return _playerControler; }
        set
        {
            if (_playerControler != null)
                Debug.Log("2 PlayerControler instanciated !");
            _playerControler = value;
        }
    }

    public BossControler bossControler
    {
        get { return _bossControler; }
        set
        {
            if (_bossControler != null)
                Debug.Log("2 BossControler instanciated !");
            _bossControler = value;
        }
    }

    public CameraControler cameraControler
    {
        get {  return _cameraControler; }
        set
        {
            if (_cameraControler != null)
                Debug.Log("2 CameraControler instanciated !");
            _cameraControler = value;
        }
    }

    public GameManager gameManager
    {
        get { return _gameManager; }
        set
        {
            if (_gameManager != null)
                Debug.Log("2 GameManager instanciated !");
            _gameManager = value;
        }
    }
}