using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] int pointsToAdd;
    [SerializeField] GameObject plusOne, minusOne;
     [SerializeField] string sceneName;
    private Renderer cubeRenderer;
    private bool stopAppear = false;
    private float coolDown= 0.4f;
    private float timeStamp;

    

    void Update(){
         if(Time.time >= timeStamp){
            minusOne.gameObject.SetActive(false);
            plusOne.gameObject.SetActive(false);
            stopAppear = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        cubeRenderer=other.gameObject.GetComponent<Renderer>();

         if (other.tag == triggeringTag && Input.GetKey(KeyCode.Z) && cubeRenderer.material.color == Color.red) {
            addScore(pointsToAdd, other);
            addText(pointsToAdd);
         }
         else if (other.tag == triggeringTag && Input.GetKey(KeyCode.X) && cubeRenderer.material.color == Color.blue) {
            addScore(pointsToAdd, other);
            addText(pointsToAdd);
         }
         else if (other.tag == triggeringTag && Input.GetKey(KeyCode.C) && cubeRenderer.material.color == Color.yellow) {
            addScore(pointsToAdd, other);
            addText(pointsToAdd);
         }
         else{
             addScore(-pointsToAdd, other);
             addText(-pointsToAdd);
             if(scoreField.GetNumber() <= 0){
                SceneManager.LoadScene(sceneName);
                }
            }
        
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }

    private void addScore(int numOfPoints, Collider2D other){
        scoreField.SetNumber(scoreField.GetNumber() + numOfPoints);
        Destroy(other.gameObject);
    }

    private void addText(int numOfPoints){
        if(!stopAppear && numOfPoints < 0){
            minusOne.gameObject.SetActive(true);
            timeStamp = Time.time +coolDown;
            stopAppear = true;
        }
        else if(!stopAppear && numOfPoints > 0){
            plusOne.gameObject.SetActive(true);
            timeStamp = Time.time + coolDown;
            stopAppear = true;
        }
    }
}
