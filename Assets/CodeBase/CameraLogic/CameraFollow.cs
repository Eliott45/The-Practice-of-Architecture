using UnityEngine;

namespace CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        public float RotationAngleX;
        public int Distance;
        public float OffsetY;
        
        [SerializeField] private Transform _following;

        private void LateUpdate()
        {
            if(!_following)
                return;
            
            var rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            var position = rotation * new Vector3(0, 0, -Distance) + FollowingPointPosition();

            var cameraTransform = transform;
            cameraTransform.rotation = rotation;
            cameraTransform.position = position;
        }

        public void Follow(GameObject following) => 
            _following = following.transform;

        private Vector3 FollowingPointPosition()
        {
            var followingPosition = _following.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}