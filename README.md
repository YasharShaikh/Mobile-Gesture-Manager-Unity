# Mobile Gesture Manager for Unity

A pair of C# scripts that demonstrate how to recognize mobile gestures and route them to gameplay or UI code through a shared event.

## Integrate the scripts

1. Copy [GestureManager.cs](GestureManager.cs) and [GestureHandler.cs](GestureHandler.cs) into your Unity project.
2. Attach **Gesture Manager** to an active GameObject. Attach **Gesture Handler** as a sample listener.
3. Enable the legacy Input Manager or **Both** under Active Input Handling. Test on a touch device and watch the console.
4. Replace the sample log statements with your own responses, or subscribe to the `GestureManager.OnGestureDectected` event in a separate component. Unsubscribe when that component is disabled.

The scripts cover directional swipes, taps, and long presses. Pinch recognition is incomplete. The two-touch branch is currently unreachable because the earlier branch handles all positive touch counts.

See [LICENSE](LICENSE) for the repository license.
