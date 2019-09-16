using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    public void ChangeHealth(float _currentHealthNormalized)
    {
        print("Current health normalized " + _currentHealthNormalized);
        healthBarSlider.value = _currentHealthNormalized;
    }
}
