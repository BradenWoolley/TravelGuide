using UnityEngine;

public class SwipeImage : MonoBehaviour
{
    public enum SwipeDirection { Left, Both, Right}
    private SwipeDirection swipe;

    [SerializeField]
    private GameObject left, right;

    /// <summary>
    /// Shows in which direction the user can swipe
    /// </summary>
    /// <param name="swipe"> Swipe direction, Left, Right, Any</param>
    public void SetSwipeDirection(SwipeDirection swipe)
    {
        this.swipe = swipe;

        switch (swipe)
        {
            case SwipeDirection.Left:
                left.SetActive(true);
                right.SetActive(false);
                break;

            case SwipeDirection.Right:
                left.SetActive(false);
                right.SetActive(true);
                break;

            case SwipeDirection.Both:
                left.SetActive(true);
                right.SetActive(true);
                break;
        }
    }
}
