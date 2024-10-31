using UnityEngine.XR.Hands.Gestures;
using System.Collections.Generic;
using UnityEngine.XR.Hands;
using UnityEngine;
using System;

public class GestureTranslator : MonoBehaviour
{
    [Header("Gesture Definitions")]
    [SerializeField] private List<Gesture> _gestureList;

    private FingerTracker _fingerTracker;

    public event Action<GestureType> GesturePerformed;

    private void Awake()
    {
        _fingerTracker = new FingerTracker();
    }

    private void OnEnable()
    {
        XRHandTrackingEvents[] handTrackingEvents = FindObjectsOfType<XRHandTrackingEvents>();
        foreach (var handTrackingEvent in handTrackingEvents)
        {
            handTrackingEvent.jointsUpdated.AddListener(GestureTranslator_JointsUpdated);
            handTrackingEvent.poseUpdated.AddListener(GestureTranslator_PoseUpdated);
        }
    }

    private void OnDisable()
    {
        XRHandTrackingEvents[] handTrackingEvents = FindObjectsOfType<XRHandTrackingEvents>();
        foreach (var handTrackingEvent in handTrackingEvents)
        {
            handTrackingEvent.jointsUpdated.RemoveListener(GestureTranslator_JointsUpdated);
            handTrackingEvent.poseUpdated.RemoveListener(GestureTranslator_PoseUpdated);
        }
    }

    private void GestureTranslator_JointsUpdated(XRHandJointsUpdatedEventArgs args)
    {
        _fingerTracker.UpdateFingerShape(args.hand);

        CheckForGestures();
    }

    private void GestureTranslator_PoseUpdated(Pose pose)
    {
        
        // This could be used for gesture refinement or hand orientation logic in the future
    }

    private void OnGesturePerformed(GestureType recognizedGesture)
    {
        GesturePerformed?.Invoke(recognizedGesture);
    }

    private void CheckForGestures()
    {
        var leftFingerShapes = _fingerTracker.GetFingerShapes(Handedness.Left);
        var rightFingerShapes = _fingerTracker.GetFingerShapes(Handedness.Right);

        foreach (var gesture in _gestureList)
        {
            if (IsGestureMatched(leftFingerShapes, rightFingerShapes, gesture, out GestureType recognizedGesture))
            {
                OnGesturePerformed(recognizedGesture); return;
            }
        }
    }

    private bool IsGestureMatched(Dictionary<XRHandFingerID, XRFingerShape> leftFingerShapes, Dictionary<XRHandFingerID, XRFingerShape> rightFingerShapes, Gesture gesture, out GestureType recognizedGesture)
    {
        bool leftHandMatched = true;
        bool rightHandMatched = true;

        List<FingerShapeCondition> leftConditions = gesture.LeftHandFingerConditions;
        if (leftConditions.Count > 0)
        {
            leftHandMatched = CheckFingerConditions(leftFingerShapes, leftConditions);
        }

        List<FingerShapeCondition> rightConditions = gesture.RightHandFingerConditions;
        if (rightConditions.Count > 0)
        {
            rightHandMatched = CheckFingerConditions(rightFingerShapes, rightConditions);
        }

        bool isMatched;
        if (gesture.RequiresBothHands)
        {

            isMatched = leftHandMatched && rightHandMatched;
        }
        else
        { 
            isMatched = leftHandMatched || rightHandMatched;
        }

        if (isMatched)
        {
            recognizedGesture = gesture.gestureType;
            return true;
        }

        recognizedGesture = GestureType.None;
        return false;
    }

    private bool CheckFingerConditions(Dictionary<XRHandFingerID, XRFingerShape> fingerShapes, List<FingerShapeCondition> conditions)
    {
        bool allConditionsMet = true;

        foreach (var condition in conditions)
        {
            XRFingerShape currentFingerShape = fingerShapes[condition.FingerID];
            bool shapeMatched = false;

            foreach (var allowedShape in condition.AllowedShapes)
            {
                if (currentFingerShape.types.HasFlag(allowedShape))
                {
                    shapeMatched = true;
                    break;
                }
            }

            if (!shapeMatched)
            {
                allConditionsMet = false;
                break;
            }
        }

        return allConditionsMet;
    }
}