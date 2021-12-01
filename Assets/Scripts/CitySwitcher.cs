using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CitySwitcher : MonoBehaviour
{
    [SerializeField]
    private TMP_Text cityName, description;
    [SerializeField]
    private Image coatOfArms;

    [SerializeField]
    private CityInfo defaultCity;

    private void Start() => ChangeInfo(defaultCity);
    public void ChangeCity(CityInfo cityInfo) => ChangeInfo(cityInfo);

    private void ChangeInfo(CityInfo cityInfo)
    {
        cityName.text = cityInfo.cityName;
        description.text = cityInfo.description;
        coatOfArms.sprite = cityInfo.coatOfArms;

        MenuManagement.instance.SetCurrentCity(cityInfo);
    }
}
