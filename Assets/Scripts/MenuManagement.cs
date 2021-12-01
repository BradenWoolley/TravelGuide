using UnityEngine;

public class MenuManagement : MonoBehaviour
{
    [Header("Page Settings")]
    [SerializeField]
    private GameObject[] cards;
    [SerializeField]
    private CityInfo currentCity;
    [SerializeField]
    private SwipeImage swipeImage;
    [SerializeField]
    private TabManager tabManager;
    [SerializeField]
    private int activityPage;
    [SerializeField]
    private int homePage;
    

    private int index = 0;

    private CreateActivityButtons activityButtons;

    public static MenuManagement instance;
    public CityInfo CurrentCity { get => currentCity; set => currentCity = value; }

    private void Awake()
    {
        instance = this;
        index = homePage;
        if (index < 1)
            swipeImage.SetSwipeDirection(SwipeImage.SwipeDirection.Right);
        else
            swipeImage.SetSwipeDirection(SwipeImage.SwipeDirection.Both);
    }

    private void Start() => activityButtons = GetComponent<CreateActivityButtons>();

    /// <summary>
    /// Set the current city to display
    /// </summary>
    /// <param name="cityInfo">Current city's information</param>
    public void SetCurrentCity(CityInfo cityInfo)
    {
        CurrentCity = cityInfo;

        if (activityButtons != null)
            activityButtons.RemoveButtons();

        if (ActivitySwitcher.switcher != null)
            ActivitySwitcher.switcher.ClearInfo();
    }

    public void SwipeLeft()
    {
        if (index == cards.Length - 1)
            return;

        index++;
        ChangeCard();
    }

    public void SwipeRight()
    {
        if (index == 0)
            return;
            
        index--;
        ChangeCard();
    }

    /// <summary>
    /// Shows the activity page
    /// </summary>
    public void GoToActivities()
    {
        index = activityPage;
        ChangeCard();
    }

    public void GoToHome()
    {
        index = homePage;
        ChangeCard();
    }

    public void GoToPhrases()
    {
        index = 0;
        ChangeCard();
    }

    public void GoToThingsToDo()
    {
        index = 2;
        ChangeCard();
    }
    private void ChangeCard()
    {
        foreach(var card in cards)
        {
            if(card != cards[index])
                card.SetActive(false);
            else
                cards[index].SetActive(true);
        }

        if (index == 0)
            swipeImage.SetSwipeDirection(SwipeImage.SwipeDirection.Right);

        else if (index == cards.Length - 1)
            swipeImage.SetSwipeDirection(SwipeImage.SwipeDirection.Left);

        else
            swipeImage.SetSwipeDirection(SwipeImage.SwipeDirection.Both);

        tabManager.SetActiveTab(index);
    }
    public void QuitApp() => Application.Quit(0);
}
