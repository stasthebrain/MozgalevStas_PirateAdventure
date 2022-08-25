using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake()
    {
        AudioListener.volume = slider.value;
        slider.onValueChanged.AddListener(value => AudioListener.volume = value);
    }
}
