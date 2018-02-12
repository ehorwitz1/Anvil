using UnityEngine;
using System.Collections.Generic;

// For now actions will be a pair of coordinates,
// In the future they will be wrapped in an action object
interface IAIControlled {
    // Client code will have to implement the backing fields
    // And it must initialize the ActionQueue on creation
    List< Vector2 > ActionQueue { get; }
    Vector2 CurrentAction{ get; }
    
    // This method will request an route from the object's current
    // position to the position specified in the method call.
    void requestRoute( Vector2 currPos );

    // This requests the next action in the queue
    void getNextAction();
}
