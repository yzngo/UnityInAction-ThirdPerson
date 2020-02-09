using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;
    void Awake() 
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    } 
    void OnDestroy() 
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnOpenSetting() {
        settingsPopup.Open();
    }

    public void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
}
