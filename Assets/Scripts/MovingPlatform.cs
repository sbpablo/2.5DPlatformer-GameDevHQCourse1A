using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   
    [SerializeField]
    private Transform _pointA;
    [SerializeField]
    private Transform _pointB;

    private bool _going=true;
    private float _timer;
    [SerializeField]
    private float _speed=1;
    
    void Start()
    {
        
       
 
        
    }

    // Update is called once per frame
    void FixedUpdate()   // Tuve que poner fixedupdate, de lo contrario se caia el personaje;
    {

        var step = _speed * Time.deltaTime;
        
        if (_going)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, step);

            if (transform.position == _pointB.position)
            {
                _going = false;
            }
        }
        else //returning
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, step);
            
            if (transform.position == _pointA.position)
            {
                _going = true;
            }

        }


        



        //transform.position=  new Vector3 ( (Mathf.PingPong(Time.time,_initialPos.x*2f)), transform.position.y, transform.position.z);


        /*
        
        if (_going)
        {
            transform.position = new Vector3(Mathf.Clamp( (Time.time - _timer) + _initialPos.x, _initialPos.x, _initialPos.x * 2) , transform.position.y, transform.position.z);
            if (transform.position.x >= _initialPos.x * 2)
            {
                _going = false;
                _timer = Time.time;
                
            }
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(_initialPos.x * 2 - (Time.time-_timer), _initialPos.x, _initialPos.x * 2), transform.position.y, transform.position.z);
            if (transform.position.x <= _initialPos.x)
            {
                _going = true;
                _timer = Time.time;
            }

        }

        */


    }
}
