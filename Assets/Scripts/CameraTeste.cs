using UnityEngine;


    public class CameraTeste: MonoBehaviour
    {

	    public Transform target1;
		public Transform target2;
		private Vector3 target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public float yPosRestriction = -1f;
        public float yPosRestrictionUp = 8;
        public float xPlusRestrict = 25f;
        public float xMinusRestrict = -25f;

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;
        private float nextTimeToSearch = 0;



		public void UpdateCameraPosition () {
			
			float targetPositionX = (target1.position.x + target2.position.x) / 2;
			float targetPositionY = (target2.position.y + target1.position.y) / 2;
			target = new Vector2 (targetPositionX, targetPositionY);
			transform.position = new Vector3 (target.x, transform.position.y, transform.position.z);
		}
		
        // Use this for initialization
        private void Start()
        {
            lastTargetPosition = target;
            offsetZ = (transform.position - target).z;
            transform.parent = null;
            

        }

        // Update is called once per frame
        private void Update()
	    {
			
		float top = Camera.main.ScreenToWorldPoint (new Vector3 (0f, Screen.height)).y;
		float bottom = Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f)).y;
		float right = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0f)).x;
		float left = Camera.main.ScreenToWorldPoint (new Vector3 (0f, 0f)).x;
		if (target1.position.x > right || target1.position.x < left || target1.position.y > top || target1.position.y < bottom || target2.position.x > right || target2.position.x < left || target2.position.y > top || target2.position.y < bottom) {

			if (Camera.main.orthographicSize < 5f) {
				Camera.main.orthographicSize += 0.01f;
			}
		}
		if (target1.position.x < right - 2 && target1.position.x > left + 2 && target1.position.y < top - 2 && target1.position.y > bottom + 2 && target2.position.x < right - 2 && target2.position.x > left + 2 && target2.position.y < top - 2 && target2.position.y > bottom + 2 ) {

			if (Camera.main.orthographicSize > 2.5f) {
				Camera.main.orthographicSize -= 0.01f;
			}
		}

			float targetPositionX = (target1.position.x + target2.position.x) / 2;
			float targetPositionY = (target2.position.y + target1.position.y) / 2;
			target = new Vector2 (targetPositionX, targetPositionY);
			transform.position = new Vector3 (target.x, transform.position.y, transform.position.z);
            if (target1 == null)
            {
                FindPlayer();
                return;
            }

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target - lastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target + lookAheadPos + Vector3.forward * offsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

            newPos = new Vector3(Mathf.Clamp(newPos.x, xMinusRestrict, xPlusRestrict), Mathf.Clamp(newPos.y, yPosRestriction, yPosRestrictionUp), newPos.z);

            transform.position = newPos;

            lastTargetPosition = target;

        }

        void FindPlayer()
        {
            if (nextTimeToSearch <= Time.time)
            {
                GameObject searchResult1 = GameObject.FindGameObjectWithTag("Player1");
                if (searchResult1 != null)
                    target1 = searchResult1.transform;
				GameObject searchResult2 = GameObject.FindGameObjectWithTag("Player2");
				if (searchResult1 != null)
					target2 = searchResult2.transform;
	                nextTimeToSearch = Time.time + 0.5f;
            }
        }


    }