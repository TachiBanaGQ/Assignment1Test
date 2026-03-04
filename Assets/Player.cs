using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float speed = 0.5f;
    private SpriteRenderer myPlayerRender;
    public InputAction move;
    public InputAction fire;
    private InputSystem_Actions InputSystem_Actions;

    private void Awake()
    {
        InputSystem_Actions = new InputSystem_Actions();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayerRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        move = InputSystem_Actions.Player.Move;
        fire = InputSystem_Actions.FindAction("Fire");
        move.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        move.Disable();
        fire.performed -= Fire; 
        fire.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        Vector2 movement = move.ReadValue<Vector2>();

        /* if(direction < 0) {
        myPlayerRender.flipX = true;
         }
        else if (direction > 1) {
             myPlayerRender.flipX = false; */
        if (movement.x != 0)
        {
            myPlayerRender.flipX = movement.x < 0;
        }
        transform.Translate(Vector2.right * movement.x * speed * Time.deltaTime);

    }

    private void Fire(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            Debug.Log("the enemy");
        }

        if (context.performed)
        {
            Debug.Log("Boing boing");
        }
    }
}
