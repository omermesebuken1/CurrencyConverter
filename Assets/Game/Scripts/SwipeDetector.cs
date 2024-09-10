using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool isSwiping = false;

    private float swipeThreshold = 300f; // Adjust this value to set the minimum swipe distance
    NavBarController navBar;

    private void Awake()
    {
        navBar = FindObjectOfType<NavBarController>();

    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    // If the touch moves, it's no longer a swipe
                    isSwiping = true;
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        endPosition = touch.position;

                        // Calculate swipe direction and distance
                        Vector2 swipeDirection = endPosition - startPosition;
                        float swipeDistance = swipeDirection.magnitude;

                        // Check if swipe distance exceeds the threshold
                        if (swipeDistance >= swipeThreshold)
                        {
                            // Check if swipe is horizontal
                            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                            {

                                // Swipe left
                                if (swipeDirection.x < 0)
                                {
                                    if (navBar.viewState < 1)
                                    {
                                        int num = navBar.viewState;
                                        num++;
                                        navBar.ChangeState(num);
                                    }

                                }
                                // Swipe right
                                else
                                {
                                    if (navBar.viewState > -1)
                                    {
                                        int num = navBar.viewState;
                                        num--;
                                        navBar.ChangeState(num);
                                    }

                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
