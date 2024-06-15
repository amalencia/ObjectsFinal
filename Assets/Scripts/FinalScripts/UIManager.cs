using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerHealth;
    [SerializeField] private TextMeshProUGUI _playerArmor;
    [SerializeField] private TextMeshProUGUI _numberOfNukes;
    [SerializeField] private TextMeshProUGUI _totalScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _gameLevel;

    public void UpdateHealthUI(int counter)
    {
        _playerHealth.text = counter.ToString();
    }

    public void UpdateArmorUI(int counter)
    {
        _playerArmor.text = counter.ToString();
    }

    public void UpdateNukeUI(int counter)
    {
        _numberOfNukes.text = counter.ToString();
    }

    public void UpdateScoreUI(int counter)
    {
        _totalScoreText.text = counter.ToString();
    }

    public void UpdateHSUI(int counter)
    {
        _highScoreText.text = counter.ToString();
    }

    public void UpdateGameLevel(int counter)
    {
        _gameLevel.text = counter.ToString();
    }

}
