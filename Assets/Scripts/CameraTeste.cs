using UnityEngine;


    public class CameraTeste: MonoBehaviour
    {

	    public Transform target1; //primeiro alvo da câmera (personagem 1)
		public Transform target2; //primeiro alvo da câmera (personagem 2)
		private Vector3 target; // alvo imaginário que fica sempre no pondo médio entre os dois personagens
        public float damping = 1; //coeficiente de "amortecimento" do movimento da câmera
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public float lookAheadMaxDistance = 2f;
        public float lookAheadZoomSpeed = 0.01f;
        public float yPosRestriction = -1f; //restrição de posição no eixo y
        public float yPosRestrictionUp = 8;
        public float xPlusRestrict = 25f; //restrição de posição no eixo x
        public float xMinusRestrict = -25f; //restrição de posição no eixo x

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;
        private float nextTimeToSearch = 0;


        //função para modificar a posição da câmera
		public void UpdateCameraPosition () {
			
			float targetPositionX = (target1.position.x + target2.position.x) / 2;
			float targetPositionY = (target2.position.y + target1.position.y) / 2;
			target = new Vector2 (targetPositionX, targetPositionY);
			transform.position = new Vector3 (target.x, transform.position.y, transform.position.z);
		}
		
        // Use this for initialization
        private void Start()
        {
            lastTargetPosition = target; //adiquire a posição inicial do alvo
            offsetZ = (transform.position - target).z;
            transform.parent = null;
            

        }

        // Função padrão do unity que é chamada após o update padrão, ou seja, a camera não vai ficar tendo espasmos
        // porque qualquer movimento do player já terá sido feito antes dessa função ser chamada
        private void FixedUpdate()
	    {
		// acha os parametros de distancia do centro da tela até a borda
		float top = Camera.main.ScreenToWorldPoint (new Vector3 (0f, Screen.height)).y;
		float bottom = Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f)).y;
		float right = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0f)).x;
		float left = Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f)).x;

        //if para verificar se um dos personagens está chegando perto do limite externo da câmera
		if (target1.position.x > (right - lookAheadMaxDistance) || target1.position.x < (left + lookAheadMaxDistance) || target1.position.y > (top - lookAheadMaxDistance) || target1.position.y < (bottom + lookAheadMaxDistance) || target2.position.x > (right - lookAheadMaxDistance) || target2.position.x < (left + lookAheadMaxDistance) || target2.position.y > (top - lookAheadMaxDistance) || target2.position.y < (bottom + lookAheadMaxDistance)) {
            //if para fazer a camera dar um zoom out
			if (Camera.main.orthographicSize < 6f) {
				Camera.main.orthographicSize += lookAheadZoomSpeed;
			}
		}
        // para verificar se um dos personagens está se aproximando do centro da câmera
        if (target1.position.x < right - lookAheadMaxDistance && target1.position.x > left + lookAheadMaxDistance && target1.position.y < top - lookAheadMaxDistance && target1.position.y > bottom + lookAheadMaxDistance && target2.position.x < right - lookAheadMaxDistance && target2.position.x > left + lookAheadMaxDistance && target2.position.y < top - lookAheadMaxDistance && target2.position.y > bottom + lookAheadMaxDistance) {
            //if para fazer a camera dar um zoom in
			if (Camera.main.orthographicSize > 2.5f) {
				Camera.main.orthographicSize -= lookAheadZoomSpeed;
			}
		}
            //declara os valores de posição do alvo imaginário
			float targetPositionX = (target1.position.x + target2.position.x) / 2;
			float targetPositionY = (target2.position.y + target1.position.y) / 2;
			target = new Vector2 (targetPositionX, targetPositionY);
			transform.position = new Vector3 (target.x, transform.position.y, transform.position.z);
            if (target1 == null)
            {
                FindPlayer();
                return;
            }
            

            //só altera a posição à frente se estiver acelerando ou mudando de direção
            float xMoveDelta = (target - lastTargetPosition).x; //variável que contem a informação se a posição do personagem está mudando

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold; //true se a mudança de posição do personagem for maior que um valor mínimo

            if (updateLookAheadTarget)
            {
                lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta); //atribui um valor que fará a câmera olhar mais para frente do personagem já que ele está correndo
            }
            else
            {
                lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed); //faz a câmera voltar ao seu centro se o personagem não estiver correndo acima da vel. mínima
            }

            Vector3 aheadTargetPos = target + lookAheadPos + Vector3.forward * offsetZ; //muda a posição da câmera de acordo com a vel. do jogador
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping); //aplica o amortecimento do movimento da câmera baseado no coeficiente

            newPos = new Vector3(Mathf.Clamp(newPos.x, xMinusRestrict, xPlusRestrict), Mathf.Clamp(newPos.y, yPosRestriction, yPosRestrictionUp), newPos.z);

            transform.position = newPos; //atribui a posição com amortecimento à câmera

            lastTargetPosition = target; //reseta a ultima posição do alvo imaginário para garantir que o calculo da vel. seja coerente

        }

        //função que assegura que a câmera nunca vai quebrar se por algum motivo inesperado o objeto de algum dos personagens sumir
        void FindPlayer()
        {
            if (nextTimeToSearch <= Time.time)
            {
                GameObject searchResult1 = GameObject.FindGameObjectWithTag("Player1"); //acha o personagem 1
                if (searchResult1 != null)
                    target1 = searchResult1.transform;
				GameObject searchResult2 = GameObject.FindGameObjectWithTag("Player2"); //acha o personagem 1
                if (searchResult2 != null)
					target2 = searchResult2.transform;
	            nextTimeToSearch = Time.time + 0.5f;
            }
        }


    }