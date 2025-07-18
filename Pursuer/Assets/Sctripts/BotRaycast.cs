using UnityEngine;

public class BotRaycast : MonoBehaviour
{
    [SerializeField] private float _rayDistance;

    public bool IsRise()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        return (Physics.Raycast(ray, out hit, _rayDistance));
    }
}
