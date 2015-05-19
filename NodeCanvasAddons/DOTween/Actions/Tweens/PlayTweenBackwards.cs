using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Play Tween Backwards")]
    [Description("Plays a given tween backwards")]
    [Icon("DOTweenTween")]
    public class PlayTweenBackwards : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBTween Tween;

        public BBBool WaitUntilFinished;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Play Tween {0} Backwards", Tween);

                if (!WaitUntilFinished.isNone && !WaitUntilFinished.isNull && WaitUntilFinished.value)
                {
                    descriptionBuilder.AppendFormat("\nAnd wait until finished");
                }

                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            if (WaitUntilFinished.value)
            {
                Tween.value.OnComplete(OnTweenComplete);
            }
            
            Tween.value.PlayBackwards();

            if (!WaitUntilFinished.value)
            {
                EndAction(true);
            }
        }

        private void OnTweenComplete()
        {
            EndAction(true);
        }
    }
}