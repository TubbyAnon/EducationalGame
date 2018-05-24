using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour {

    
    int answer;
    // Use this for initialization
    void Start () {

        QuestionHandler qh = new QuestionHandler();

        answer = Random.Range(qh.getCurrentAnswer() - 20, qh.getCurrentAnswer() + 20);

        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;

        var spriteTransform = parent.transform;
        var text = GetComponent<TextMesh>();
        var pos = spriteTransform.position;
        text.text = answer.ToString();
    }

    private void Update()
    {
        
    }
}
