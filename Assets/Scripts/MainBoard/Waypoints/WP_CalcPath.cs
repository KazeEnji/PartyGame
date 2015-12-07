using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class Waypoints : MonoBehaviour
{
    [SerializeField] private int waypointCount = 0;
    [SerializeField] private int distanceToMove;

    /* Method for calculating the distance around the map without a pathfinding
     * game object. The _dist variable is the remaining movement. The _source
     * variable is the waypoint that invoked this method. So when this waypoint
     * invokes this method in the surrounding waypoints, it will pass in itself.
     * This is to prevent the pathfinder from going between the same two
     * waypoints repeatedly and giving false movement data.
     */
    public void CalcDist(int _dist, GameObject _source, List<GameObject> _path)
    {
        /* Adds this gameobject to the list of waypointsto calculate the
         * proper path when the user clicks on it.
         */
        _path.Add(this.gameObject);

        //This prevents the player from clicking on this if it isn't an ending waypoint.
        finalWP = false;

        /* If this is the first waypoint in the chain, you need to add one
         * to the move distance. This must be executed BEFORE the if statement
         * looking for how many connected waypoints there are. If this doesn't
         * occur first, you'll be adding 1 to the distance every time you run
         * into a dead end. The other option is to add one to the original value
         * of the distance that's passed into this method prior to the method
         * being invoked but this seemed more logical.
         */
        if (_source == this.gameObject)
        {
            _dist++;
        }

        /* Determine if this is the last waypoing in the chain.
         * If it is, then switch the source game object so that
         * the pathfinding can continue back the way it came in
         * case there are more moves available.
         */
        if (waypointCount <= 1)
        {
            _source = this.gameObject;
        }

        //Determine if this is the final stop.
        if (_dist <= 1)
        {
            //Saves the current path list to the waypoint.
            pathList = _path;

            //This is the final waypoint in the chain.
            finalWP = true;

            //Blue signifies viable moves for the player.
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        //If this isn't the final stop, continue pathfinding.
        else
        {
            //Yellow signifies a registered move but not the end.
            this.GetComponent<Renderer>().material.color = Color.yellow;

            _dist -= 1;

            //Invoke this same method on the surrounding waypoints.
            if (forwardWP != null && _source != forwardWP)
            {
                forwardWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                forwardWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
            if (backWP != null && _source != backWP)
            {
                backWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                backWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
            if (leftWP != null && _source != leftWP)
            {
                leftWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                leftWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
            if (rightWP != null && _source != rightWP)
            {
                rightWP.GetComponent<Waypoints>().SetMoveDistance(distanceToMove);
                rightWP.GetComponent<Waypoints>().CalcDist(_dist, this.gameObject, _path);
            }
        }
    }
}