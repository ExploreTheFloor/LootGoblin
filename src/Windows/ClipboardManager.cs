namespace LootGoblin.Windows
{
    public class ClipboardManager
    {
        public static async Task CopyToClipboard(string text)
        {
            var thread = new Thread(() => { Clipboard.SetText(text); });
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join(); //Wait for the thread to end}
        }
    }
}