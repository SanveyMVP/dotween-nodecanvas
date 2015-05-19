using System.Text;
using Assets.NodeCanvasAddons.DOTween.Types;
using DG.Tweening;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Sequences
{
    [Category("DOTween/Sequences")]
    [Name("Play Sequence Forward")]
    [Description("Plays a given sequence forwards")]
    [Icon("DOTweenTween")]
    public class PlaySequenceForward : ActionTask
    {
        [RequiredField]
        [BlackboardOnly]
        public BBSequence Sequence;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Play {0} Forwards", Sequence);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            Sequence.value.PlayForward();
            EndAction(true);
        }
    }
}