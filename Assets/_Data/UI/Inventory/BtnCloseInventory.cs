public class BtnCloseInventory : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
