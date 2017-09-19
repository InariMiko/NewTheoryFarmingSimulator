using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{

    public float verticalScrollArea = 10f;
    public float horizontalScrollArea = 10f;
    public float verticalScrollSpeed = 10f;
    public float horizontalScrollSpeed = 10f;

    public void EnableControls(bool _enable)
    {
        if (_enable)
        {
            ZoomEnabled = true;
            MoveEnabled = true;
        }
        else
        {
            ZoomEnabled = false;
            MoveEnabled = false;
        }
    }
    public bool ZoomEnabled = true;
    public bool MoveEnabled = true;

    private Vector2 _mousePos;
    private Vector3 _moveVector;
    private int _xMove;
    private int _yMove;
    private int _zMove;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Input.mousePosition;

        //Move camera if mouse is at the edge of the screen

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _xMove = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _xMove = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _zMove = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _zMove = -1;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)|| 
            Input.GetKeyUp(KeyCode.LeftArrow) || 
            Input.GetKeyUp(KeyCode.DownArrow) || 
            Input.GetKeyUp(KeyCode.UpArrow))
        {
            _xMove = 0;
            _yMove = 0;
            _zMove = 0;
        }
        else
        {
            _yMove = 0;
        }
        // Zoom Camera in or out
        if (ZoomEnabled)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                _yMove = 1;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                _yMove = -1;
            }
            else
            {
                _yMove = 0;
            }
        }
        else
        {
            _zMove = 0;
        }
        //move the object
        MoveMe(_xMove, _yMove, _zMove);
    }

    private void MoveMe(int x, int y, int z)
    {
        _moveVector = (new Vector3(x * horizontalScrollSpeed,
                                         y * verticalScrollSpeed, z * horizontalScrollSpeed) * Time.deltaTime);
        transform.Translate(_moveVector, Space.World);
    }

 
}