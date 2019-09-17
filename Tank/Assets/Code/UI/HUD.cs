using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text attemp;
    [SerializeField]
    private Text weaponName;
    [SerializeField]
    private Image weaponImage;

    [SerializeField]
    private GameoverPanel gameoverScreen;

    public void SetScore(int _score)
    {
        scoreText.text = _score.ToString();
    }

    public void SetAttemp(int _attemp)
    {
        attemp.text = _attemp.ToString();
    }

    public void SetaWeaponName(string _name)
    {
        weaponName.text = _name.ToString();
    }
    public void SetWeaponImage(Sprite _sprite)
    {
        weaponImage.sprite = _sprite;
    }

    public void ShowGameoverScreen(int _finalScore)
    {
        gameoverScreen.gameObject.SetActive(true);
        gameoverScreen.finalScore.text = _finalScore.ToString();
    }
}
