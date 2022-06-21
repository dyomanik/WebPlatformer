using UnityEngine;
namespace My2DPlatformer
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        [SerializeField]
        private int speed;

        [SerializeField]
        private float offsetX;

        [SerializeField]
        private float offsetY;

        [SerializeField]
        private float offsetZ;

        private Vector3 temp;

        private void LateUpdate()
        {
            temp = player.position;
            temp.x += offsetX;
            temp.y += offsetY;
            temp.z += offsetZ;
            transform.position = Vector3.Lerp(transform.position, temp, speed * Time.deltaTime);
        }
    }
}