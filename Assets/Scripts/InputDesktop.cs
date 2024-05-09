using UnityEngine;

public class InputDesktop : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;
    [SerializeField] private int _inputValue = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_inputValue))
            _explosion.HittingCube();
    }
}
