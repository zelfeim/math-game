using System.Linq;
using UnityEngine;

namespace Game.Camera
{
    public class Camera : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            // TODO: make it more resource efficient
            var camPos = UnityEngine.Camera.main!.transform.position;
            var playerPos = GameObject.FindGameObjectsWithTag("Player").First().transform.position;
        
            UnityEngine.Camera.main.transform.position = new Vector3(camPos.x, playerPos.y, camPos.z);
        }
    }
}
