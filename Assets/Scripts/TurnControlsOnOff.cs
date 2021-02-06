using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnControlsOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameplayControlsWindow;

    public bool _gameplayControlsWindowIsEnabled;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TurnControlsPanelOnOff);
    }

    private void TurnControlsPanelOnOff()
    {
        _gameplayControlsWindowIsEnabled ^= true;
        _gameplayControlsWindow.SetActive(_gameplayControlsWindowIsEnabled);
    }


}
