using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI healthLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private InventoryPopup inventoryPopup;
    [SerializeField] private TextMeshProUGUI levelEnding;

    private int _score;
    void Awake() 
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHelathUpdated);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    } 
    void OnDestroy() 
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHelathUpdated);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
        Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
        Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
    }
    // Start is called before the first frame update
    void Start()
    {
        OnHelathUpdated();
        levelEnding.gameObject.SetActive(false);
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
        inventoryPopup.gameObject.SetActive( false );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            bool isShowing = settingsPopup.gameObject.activeSelf;
            settingsPopup.gameObject.SetActive(!isShowing);

            if (isShowing) {
                // Cursor.lockState = CursorLockMode.Locked;
                // Cursor.visible = false;
            } else {
                // Cursor.lockState = CursorLockMode.None;
                // Cursor.visible = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            bool isShowing = inventoryPopup.gameObject.activeSelf;
            inventoryPopup.gameObject.SetActive(!isShowing);
            inventoryPopup.Refresh();
        }
    }

    public void OnOpenSetting() {
        settingsPopup.Open();
    }

    public void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }

    private void OnHelathUpdated() 
    {
        string message = "Health: " + Managers.Player.health + "/" + Managers.Player.maxHealth;
        healthLabel.text = message;
    }
    private void OnLevelComplete()
    {
        StartCoroutine(CompleteLevel());
    }
    private IEnumerator CompleteLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Complete!";

        yield return new WaitForSeconds(2);

        Managers.Mission.GoToNext();
    }

    private void OnLevelFailed() 
    {
        StartCoroutine(FailLevel());
    }

    private IEnumerator FailLevel()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "Level Failed";
        yield return new WaitForSeconds(2);
        Managers.Player.Respawn();
        Managers.Mission.RestartCurrent();
    }

    private void OnGameComplete()
    {
        levelEnding.gameObject.SetActive(true);
        levelEnding.text = "You Finished the Game !";
    }

}
