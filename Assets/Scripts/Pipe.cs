using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private void Update()
        {
            if (GameManager.Instance.isGameOver)
                return;

            transform.position += (Vector3.left * Time.deltaTime * speed);
        }
    }
}