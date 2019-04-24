using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject Ship;
    private Vector2 StartPos;

    public float Speed;

    // Use this for initialization
    void Start()
    {
        //Ship = GameObject.Find("Player");
        transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y, this.gameObject.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = Speed * Time.deltaTime;

        Vector3 Position = this.transform.position;
        Position.x = Mathf.Lerp(this.transform.position.x, Ship.transform.position.x, interpolation);
        Position.y = Mathf.Lerp(this.transform.position.y, Ship.transform.position.y, interpolation);

        this.transform.position = Position;

    }
}
