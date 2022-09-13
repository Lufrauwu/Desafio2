using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("How much time to wait before destroying " +
             "the tile after reaching the end")]
 
    [SerializeField] private GameObject _spawnPointCenter;
    [SerializeField] private GameObject _spawnPointLeft;
    [SerializeField] private GameObject _spawnPointRight;
    [SerializeField] private GameObject _obstaclePrefab;
    private int _randomNumber = default;
    private float destroyTime = 2.5f;

    private void OnTriggerEnter(Collider col)
    {
        // First check if we collided with the player
        if (col.gameObject.GetComponent<PlayerController>())
        {
            // If we did, spawn a new tile
            GameObject.FindObjectOfType<GameManager>
                ().SpawnNextTile();
            // And destroy this entire tile after a short delay
            Destroy(transform.parent.gameObject, destroyTime);
        }

        _randomNumber = Random.Range(1, 6);

        switch (_randomNumber)
        {
            
            case 1:
                    Instantiate(_obstaclePrefab, _spawnPointLeft.transform.position, Quaternion.identity);
                break;            
            case 2:
                    Instantiate(_obstaclePrefab, _spawnPointLeft.transform.position, Quaternion.identity);
                break;           
            case 3:
                    Instantiate(_obstaclePrefab, _spawnPointCenter.transform.position, Quaternion.identity);
                break;           
            case 4:
                    Instantiate(_obstaclePrefab, _spawnPointCenter.transform.position, Quaternion.identity);
                break;           
            case 5:
                    Instantiate(_obstaclePrefab, _spawnPointRight.transform.position, Quaternion.identity);
                break;            
            case 6:
                    Instantiate(_obstaclePrefab, _spawnPointRight.transform.position, Quaternion.identity);
                break;

            default:
                break;
        }

    }

    IEnumerator HideObstacle(GameObject obstacle)
    {
        yield return new WaitForSeconds(2f);
        obstacle.SetActive(false);
    }    
}