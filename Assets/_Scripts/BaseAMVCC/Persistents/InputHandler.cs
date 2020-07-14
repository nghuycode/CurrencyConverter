using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MiniGame.Utility;

namespace MiniGame.General
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance;
        public List<Observer> obs;
        public TouchState State { get { return _state; } }
        private TouchState _state = TouchState.Drop;

        private Vector3 _startTouchPos;
        private float diffX, diffY;
        private float startFrame;

        private void Awake()
        {
            Instance = this;
        }

        public void Init()
        {
            obs.Clear();
        }
        public void AddObservers(Observer observer)
        {
            obs.Add(observer);
        }
        public GameObject GetHoveredObject()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

            if (hit.collider == null) return null;
            return hit.collider.gameObject;
        }
        public GameObject GetHoldObject()
        {
            if (!Input.GetMouseButtonDown(0)) return null;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

            if (hit.collider == null || Input.GetMouseButtonUp(0)) return null;
            return hit.collider.gameObject;
        }
        public GameObject GetClickedObject()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ClickableObject"));

            if (hit.collider == null) return null;
            if (Input.GetMouseButtonUp(0))
                return hit.collider.gameObject;
            else return null;
        }
    
        public bool DropObject()
        {
            return (Input.GetMouseButtonUp(0));
        }
        private void MouseCheck()
        {
            if (Input.GetMouseButtonDown(0) && _state == TouchState.Drop)
            {
                _startTouchPos = Input.mousePosition;
                _state = TouchState.Start;
                startFrame = Time.realtimeSinceStartup;
            }

            if (_state == TouchState.Start)
            {
                if (Input.mousePosition != _startTouchPos)
                {
                    _state = TouchState.Drag;
                    Drag();
                }
            }
            if (_state == TouchState.Drag)
                Drag();
            if (Input.GetMouseButtonUp(0))
            {
                _state = TouchState.Drop;
                if (Time.realtimeSinceStartup - startFrame < 0.1f)
                    Swipe();
            }
        }
        private void KeyboardCheck()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                foreach (Observer observer in obs)
                    observer.OnReceiveKey(KeyCode.Space);
            if (Input.GetKeyDown(KeyCode.Backspace))
                foreach (Observer observer in obs)
                    observer.OnReceiveKey(KeyCode.Backspace);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                foreach (Observer observer in obs)
                    observer.OnReceiveKey(KeyCode.LeftArrow);
            if (Input.GetKeyDown(KeyCode.RightArrow))
                foreach (Observer observer in obs)
                    observer.OnReceiveKey(KeyCode.RightArrow);
        }

        #region Move Command Definition
        void Swipe()
        {
            float disX = Mathf.Abs(Input.mousePosition.x - _startTouchPos.x);
            float disY = Mathf.Abs(Input.mousePosition.y - _startTouchPos.y);
            if (disX > diffX && disX > disY)
            {
                if (Input.mousePosition.x > _startTouchPos.x)
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.SwipeRight);
                else
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.SwipeLeft);
            }

            if (disY > diffY && disY > disX)
            {
                if (Input.mousePosition.y > _startTouchPos.y)
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.SwipeUp);
                else
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.SwipeDown);
            }
        }
        void Drag()
        {
            float disX = Mathf.Abs(Input.mousePosition.x - _startTouchPos.x);
            float disY = Mathf.Abs(Input.mousePosition.y - _startTouchPos.y);
            if (disX > diffX && disX > disY)
            {
                if (Input.mousePosition.x > _startTouchPos.x)
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.DragRight);
                else
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.DragLeft);
            }

            if (disY > diffY && disY > disX)
            {
                if (Input.mousePosition.y > _startTouchPos.y)
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.DragUp);
                else
                    foreach (Observer observer in obs)
                        observer.OnReceiveInput(Movement.DragDown);
            }
        }
        #endregion
        private void Update()
        {
            MouseCheck();
            KeyboardCheck();
        }
    }
}
