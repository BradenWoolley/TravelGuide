using System.Collections.Generic;
using UnityEngine;

public class ActivityHandler : MonoBehaviour
{

    [SerializeField]
    private List<Activity> activities = new List<Activity>();

    public enum ActivityType { Museum = 0, Restaurant, Bar, Sites, TakeAway, CoffeeShops, Markets, YugoArchitecture, LocalFood, Cinema }
    private ActivityType currentActivity;

    [SerializeField]
    private CreateActivityButtons activityButton;

    private void Awake() 
    {
        activityButton.SetHandler(this);

        var acts = Resources.LoadAll("Activities");

        foreach(var item in acts)
        {
            activities.Add((Activity)item);
        }
    }

    public void SetActivity(int activity)
    {
        currentActivity = (ActivityType)activity;

        ShowActivities();

        MenuManagement.instance.GoToActivities();
    }

    public void ShowActivities()
    {
        //foreach item of activity type and city

        activityButton.RemoveButtons();

        ActivitySwitcher.switcher.ClearInfo();

        List<Activity> current = new List<Activity>();

        foreach(Activity activity in activities)
        {
            if(activity.type == currentActivity && activity.cityInfo.cityName == MenuManagement.instance.CurrentCity.cityName)
            {
                current.Add(activity);
            }
        }

        activityButton.CreateNewActivity(current);
    }

    public void ShowCurrentActivity(Activity activity) => 
        ActivitySwitcher.switcher.SetInfo(activity.activityName, activity.desciption, activity.logo, activity.url);


}
