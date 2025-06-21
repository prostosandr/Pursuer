using UnityEngine;

public class InputReader : MonoBehaviour
{
    const string MouseY = "Mouse Y";
    const string MouseX = "Mouse X";
    const string Vertical = "Vertical";
    const string Horizontal = "Horizontal";

    public float GetVerticalAxis()
    {
        return Input.GetAxis(Vertical);
    }

    public float GetHorizontalAxis()
    {
        return Input.GetAxis(Horizontal);
    }

    public float GetMouseXAxis()
    {
        return Input.GetAxis(MouseX);
    }

    public float GetMouseYAxis()
    {
        return Input.GetAxis(MouseY);
    }
}
