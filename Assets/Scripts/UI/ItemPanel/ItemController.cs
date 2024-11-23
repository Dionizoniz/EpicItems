using EpicItems.Core.DataServer;
using EpicItems.Core.Engine;
using EpicItems.UI.Setup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EpicItems.UI.ItemPanel
{
    public class ItemController : ExtendedMonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _numberLabel;
        [SerializeField]
        private TextMeshProUGUI _descriptionLabel;

        [Space, SerializeField, ColorUsage(true, true)]
        private Color _specialEffectColor;
        [SerializeField]
        private Image _specialEffectImage;

        [Space, SerializeField]
        private Image _categoryImage;
        [SerializeField]
        private ItemSetup _itemSetup;

        public void Initialize(int itemNumber, DataItem dataItem)
        {
            _numberLabel.text = itemNumber.ToString();
            _descriptionLabel.text = dataItem.Description;

            SetupSpecialEffectImage(dataItem);
            TrySetupCategoryImage(dataItem);
        }

        private void SetupSpecialEffectImage(DataItem dataItem)
        {
            _specialEffectImage.color = _specialEffectColor;
            _specialEffectImage.gameObject.SetActive(dataItem.Special);
        }

        private void TrySetupCategoryImage(DataItem dataItem)
        {
            Sprite categorySprite = _itemSetup.TryFindSpriteBy(dataItem.Category);

            if (categorySprite != null)
            {
                _categoryImage.sprite = categorySprite;
            }
            else
            {
                Debug.LogError($"Missing category setup [{dataItem.Category}] in ItemController.");
            }
        }
    }
}
