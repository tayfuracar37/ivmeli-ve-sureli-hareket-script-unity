using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class altigenkontrol : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket a��s�
    private float movementSpeed = 6f; // Hareket h�z�

    public int scoreone=1;  // private score variable

    private bool hasCollided = false;






    private void OnTriggerEnter(Collider other)
    {

        if (hasCollided) // E�er zaten bir kere temas etmi�se
            return;


        if (other.CompareTag("SixAngle"))
        {


            StartCoroutine(MoveCylinder());
            PatternMove.Instance.IncreaseScore(scoreone);
            hasCollided = true;
        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("Cube") || other.CompareTag("FiveAngle") || other.CompareTag("Triangle"))
        {



            PatternMove.Instance.restartfactor = true;


        }

         System.Collections.IEnumerator MoveCylinder()
        {

            float elapsedTime = 0f;
            float duration = 0.5f; // Hareket s�resi

            while (elapsedTime < duration)
            {
                // Harek
                transform.Translate(Vector3.right * -1 * movementSpeed * Time.deltaTime * 2.5f);

                // D�mme
                transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }

    
  
}
