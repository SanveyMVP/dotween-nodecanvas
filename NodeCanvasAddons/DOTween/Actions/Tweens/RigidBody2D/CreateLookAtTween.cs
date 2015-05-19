using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;
using UnityEngine;

namespace NodeCanvasAddons.DOTween.Tweens.RigidBody2D
{
    [Category("DOTween/Tweens/RigidBody2D")]
    [Name("Create Look At Tween")]
    [Description("Creates a rotation tween for configuration or use")]
    [Icon("DOTweenTween")]
    [AgentType(typeof(Rigidbody2D))]
    public class CreateLookAtTween : ActionTask
    {
        [RequiredField]
        public BBVector2 LookAt;

        [RequiredField]
        public BBFloat Duration;
        public AxisConstraint AxisConstraint;

        [BlackboardOnly]
        public BBTween CreatedTween;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("LookAt Tween To {0}", LookAt);
                descriptionBuilder.AppendFormat("\nIn {0} with {1}", Duration, AxisConstraint);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            var tweener = ((Rigidbody)agent).DOLookAt(LookAt.value, Duration.value, AxisConstraint);
            tweener.Pause();

            CreatedTween.value = tweener;
            EndAction(true);
        }
    }
}