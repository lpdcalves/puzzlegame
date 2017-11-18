using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public Vector3 target;
    public Vector3 offset;
    private Vector3 lastTargetPosition;

    public float smoothspeed = 10f;

    public float yUpRestriction; //restrição de posição no eixo y
    public float yDownRestriction;
    public float xRightRestrict; //restrição de posição no eixo x
    public float xLeftRestrict;
    public float lookAheadMaxDistance = 3f;
    public float lookAheadMinDistance = 0.5f;

    private void FixedUpdate()
    {
        //estabelece a posição do ponto médio entre os dois personagens e coloca isso na variavel target contanto que esse valor
        //não eteja fora da restrição delimitada pelas variaveis restrict acima
        //a função que impede os valores menores e maiores que o restrict de irem para a variavel target é a função Mathf.Clamp
        float targetPositionX = (player1.position.x + player2.position.x) / 2;
        float targetPositionY = (player1.position.y + player2.position.y) / 2;
        target = new Vector2(Mathf.Clamp(targetPositionX, xLeftRestrict,xRightRestrict), Mathf.Clamp(targetPositionY, yDownRestriction, yUpRestriction));

        //desired position é a posição que queremos que a camera fique (posição do target + posição offset que é definida no unity, só para a camera não ficar em cima do jogador)
        //smoothed position é um vetor de 3 posições criado pela função Lerp, essa função suaviza um movimento entre duas posições(transform.position e desiredPosition)
        //de acordo com um coeficiente, que no caso é a variavel smoothspeed
        //por fim o algoritimo iguala a posição da camera (transform.position) à posição que acabou de ser calculada
        Vector3 desiredPosition = target + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed * Time.deltaTime);
        transform.position = smoothedPosition;


        // acha os parametros de distancia do centro da tela até a borda
		float top = Camera.main.ScreenToWorldPoint (new Vector3 (0f, Screen.height)).y;
		float bottom = Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f)).y;
		float right = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0f)).x;
		float left = Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f)).x;

        //define duas variaveis que são usadas para saber a velocidade do target, se for acima de 0.01 o programa permite que o zoom da camera seja alterado
        //(isso evita que a camera fique tremendo enquanto os jogadores estão parados)
        float xMoveDelta = (target - lastTargetPosition).x;
        float yMoveDelta = (target - lastTargetPosition).y;
        bool updateZoom = (Mathf.Abs(xMoveDelta) > 0.001) || (Mathf.Abs(yMoveDelta) > 0.001);

        //if para verificar se um dos personagens está chegando perto do limite externo da câmera definido pela variável lookAheadMaxDistance
        if (updateZoom)
        {
            if (player1.position.x > (right - lookAheadMaxDistance) || player1.position.x < (left + lookAheadMaxDistance) || player1.position.y > (top - lookAheadMaxDistance) || player1.position.y < (bottom + lookAheadMaxDistance) || player2.position.x > (right - lookAheadMaxDistance) || player2.position.x < (left + lookAheadMaxDistance) || player2.position.y > (top - lookAheadMaxDistance) || player2.position.y < (bottom + lookAheadMaxDistance))
            {
                //if para fazer a camera dar um zoom out mas impede ela de dar um zoom infinito
                if (Camera.main.orthographicSize < 6f)
                {
                    Camera.main.orthographicSize += 0.02f;
                }
            }

            // para verificar se um dos personagens está se aproximando do centro da câmera
            if (player1.position.x < right - lookAheadMinDistance && player1.position.x > left + lookAheadMinDistance && player1.position.y < top - lookAheadMinDistance && player1.position.y > bottom + lookAheadMinDistance && player2.position.x < right - lookAheadMinDistance && player2.position.x > left + lookAheadMinDistance && player2.position.y < top - lookAheadMinDistance && player2.position.y > bottom + lookAheadMinDistance)
            {
                //if para fazer a camera dar um zoom in mas impede ela de dar um zoom infinito
                if (Camera.main.orthographicSize > 2.5f)
                {
                    Camera.main.orthographicSize -= 0.02f;
                }
            }
        }
            
        lastTargetPosition = target;

    }

}
