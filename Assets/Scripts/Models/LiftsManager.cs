using System;
using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public sealed class LiftsManager 
    {
        private List<LevelObjectView> _liftViews;
        private List<LevelObjectView> _turnTriggers;
        private JointMotor2D _jointMotor;

        public LiftsManager(List<LevelObjectView> liftViews, List<LevelObjectView> turnTriggers)
        {
            _liftViews = liftViews;
            _turnTriggers = turnTriggers;
        }
    }
}