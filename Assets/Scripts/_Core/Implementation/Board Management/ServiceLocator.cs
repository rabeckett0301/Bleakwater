using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameMap;
    private static ServiceLocator _instance;

    public static IGameMap GameMap { get; private set; }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError("An instance has already been established, only one service locator should exist per scene");
            Destroy(this);
        }
        else
        {
            _instance = this;
            if(_gameMap.TryGetComponent(out IGameMap gameMap))
            {
                GameMap = gameMap;
            }
            else
            {
                Debug.LogError($"{nameof(ServiceLocator)}: {_gameMap} does not contain component of type IGameMap!");
            }
        }
    }
    private void OnDestroy()
    {
        if ( _instance == this)
        {
            _instance = null;
        }
    }
}
