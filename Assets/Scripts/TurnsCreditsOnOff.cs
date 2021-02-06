using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnsCreditsOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject _creditsWindow;

    private bool _creditsWindowIsOnOff;

    TurnControlsOnOff _setControlsOff;
    
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(TurnsCreditsWindowOnOff);
        
    }

    private void TurnsCreditsWindowOnOff()
    {
        _creditsWindowIsOnOff ^= true;
        _creditsWindow.SetActive(_creditsWindowIsOnOff);
    }
}
