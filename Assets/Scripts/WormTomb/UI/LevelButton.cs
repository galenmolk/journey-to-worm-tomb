using MolkExtras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb.UI
{
    public class LevelButton : Construct<Level>
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text levelText;
        
        public void Load()
        {
            SceneLoader.LoadScene(Model);
        }
        
        protected override void CustomConfigure(Level model)
        {
            base.CustomConfigure(model);
            Get<Image>().SetInstanceProp(mat => { mat.SetColor(ShaderParams.ColorOne, model.ColorOne); });
            Get<Image>().SetInstanceProp(mat => { mat.SetColor(ShaderParams.ColorTwo, model.ColorTwo); });
            levelText.text = (model.Index + 1).ToString();
        }
    }
}
