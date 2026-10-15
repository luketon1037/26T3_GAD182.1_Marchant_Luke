using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// Will hold a list of all the cars that exist in the race
/// </summary>
public class CardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private RectTransform canvasParent;  // The Canvas Panel transform
    private void Start()
    {
        // Start the loop when the game begins
        StartCoroutine(ThreeSecondLoop());
    }
    private IEnumerator ThreeSecondLoop()
    {
        // while(true) creates an infinite loop, but the "yield" 
        // prevents it from crashing your game.
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(.3f);
        }
    }

    public void Spawn()
    {
        // Place the code you want to run here
        Debug.Log("This message prints every 3 seconds");
        GameObject image = Instantiate(prefabToSpawn, canvasParent);
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
        rectTransform.localScale = Vector3.one;
        float canvasWidth = canvasParent.rect.width;
        float canvasHeight = canvasParent.rect.height;
        float randomX = Random.Range(-canvasWidth / 2f, canvasWidth / 2f);
        float randomY = Random.Range(-canvasHeight / 2f, canvasHeight / 2f);
        rectTransform.anchoredPosition = new Vector2(randomX, randomY);
    }
}
