using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset actionAsset;
    public InputAction moveAction;

    public Vector2 moveVector;

    public int speed = 5;
    public int rotSpeed = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        actionAsset.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        actionAsset.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveAction = actionAsset.FindAction("Move");

    }
    // Update is called once per frame
    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        this.gameObject.transform.Translate(0, 0, moveVector.y * speed * Time.deltaTime);
        this.gameObject.transform.Rotate(0, moveVector.x * rotSpeed * Time.deltaTime, 0);

    }
}