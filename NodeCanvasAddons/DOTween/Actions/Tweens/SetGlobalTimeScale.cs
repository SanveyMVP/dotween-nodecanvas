using System.Text;
using NodeCanvas;
using NodeCanvas.Variables;

namespace NodeCanvasAddons.DOTween.Tweens
{
    [Category("DOTween/Tweens")]
    [Name("Set Time Scale")]
    [Description("Sets the global time scale for all tweens")]
    [Icon("DOTweenTween")]
    public class SetGlobalTimeScale : ActionTask
    {
        [RequiredField]
        public BBFloat TimeScale;

        protected override string info
        {
            get
            {
                var descriptionBuilder = new StringBuilder();
                descriptionBuilder.AppendFormat("Setting Time Scale To {0}", TimeScale);
                return descriptionBuilder.ToString();
            }
        }

        protected override void OnExecute()
        {
            DG.Tweening.DOTween.timeScale = TimeScale.value;
            EndAction(true);
        }
    }
}