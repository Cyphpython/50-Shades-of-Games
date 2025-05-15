using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CraftingUI : MonoBehaviour
{
    public static CraftingUI instance;

    public Slot[] inputSlot;
    public Slot outputSlot;
    public Button combineButton;

    public CraftingRecipe[] allRecipes;

    private void Awake()
    {
        instance = this;
        combineButton.interactable = false;
        combineButton.onClick.AddListener(AttemptCraft);
    }

    // Update is called once per frame
    void Update()
    {
        combineButton.interactable = GetMatchingRecipe() != null;
    }

    private CraftingRecipe GetMatchingRecipe()
    {
        var currentItem = inputSlot
            .Where(slot => slot.currentItem !=null)
            .Select(slot => slot.currentItem)
            .OrderBy(i => i.name) //tri
            .ToArray();

        foreach (var recipes in allRecipes)
        {
            var ingredients = recipes.ingredients.OrderBy(i => i.name).ToArray();
            if (ingredients.SequenceEqual(currentItem)) return recipes;
        }
        return null;
    }

    public void AttemptCraft()
    {
        CraftingRecipe recipe = GetMatchingRecipe();
        if (recipe != null)
        {
            foreach (var slot  in inputSlot) slot.Clear();
            outputSlot.SetItem(recipe.result);
            Inventory.Instance?.AddItem(recipe.result);
            FlowchartManager.SetBoolVar("HasPowder");
        }
    }
}
